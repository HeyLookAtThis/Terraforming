using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsInstantiator : MonoBehaviour
{
    [SerializeField] private Water _water;
    [SerializeField] private LevelGrid _grid;
    [SerializeField] private LevelGenerator _levelGenerator;

    protected LevelGrid levelGrid => _grid;

    private void OnEnable()
    {
        _levelGenerator.Launched += Create;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= Create;
    }

    public abstract void Create(uint currentLevel);

    public abstract void SetDefaultState();

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
        float rayOriginHeight = 1f;

        Vector3 rayPoint = new Vector3(position.x, position.y + rayOriginHeight, position.z);
        Physics.Raycast(rayPoint, Vector3.down, out RaycastHit hit);

        if (hit.collider != null)
            if (hit.collider.TryGetComponent<Ground>(out Ground ground))
                return true;

        return false;
    }
}