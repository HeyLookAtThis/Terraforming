using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsInstantiator : MonoBehaviour
{
    [SerializeField] private Water _water;

    private LevelGrid _grid;
    private LevelGenerator _levelGenerator;

    private List<LevelObject> _activeObjects = new List<LevelObject>();

    protected bool wasCreated;

    protected LevelGrid levelGrid => _grid;

    protected IReadOnlyList<LevelObject> activeObjects => _activeObjects;

    protected void Awake()
    {
        _levelGenerator = GetComponentInParent<LevelGenerator>();
        _grid = GetComponentInParent<LevelGrid>();
    }

    protected virtual void OnEnable()
    {
        _levelGenerator.Launched += OnCreate;
    }

    protected virtual void OnDisable()
    {
        _levelGenerator.Launched -= OnCreate;
    }

    public virtual void OnCreate(uint currentLevel)
    {
        if (wasCreated)
            ReturnDefaultState();
    }

    public void ReturnDefaultState()
    {
        if (_activeObjects != null)
        {
            foreach (var activeObject in _activeObjects)
                activeObject.ReturnToDefaultState();

            if (_activeObjects[0].GetType() != typeof(Grass))
                _activeObjects.Clear();
        }
    }

    protected void AddActiveObject(LevelObject activeObject)
    {
        _activeObjects.Add(activeObject);
    }

    protected Vector3 GetAllowedCoordinate()
    {
        bool isAllowed = false;
        float waterDistance = 10f;

        Vector3 position = new Vector3();

        while (isAllowed != true)
        {
            position = _grid.GetRandomCellCoordinate();

            isAllowed = IsEmptyGround(position) && Vector3.Distance(position, _water.transform.position) > waterDistance;
        }

        return position;
    }

    protected bool IsEmptyGround(Vector3 position)
    {
        float rayOriginHeight = 0.1f;

        Vector3 rayPoint = new Vector3(position.x, position.y + rayOriginHeight, position.z);
        Physics.Raycast(rayPoint, Vector3.down, out RaycastHit hit);

        if (hit.collider != null)
            if (hit.collider.TryGetComponent<Ground>(out Ground ground))
                return true;

        return false;
    }
}