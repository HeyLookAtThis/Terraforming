using System.Collections.Generic;
using UnityEngine;

public class GrassCreator : MonoBehaviour
{
    [SerializeField] private Grass _grass;
    [SerializeField] private LevelGrid _grid;

    private List<Grass> _grassList = new List<Grass>();

    private bool _isCreated;

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        if (_isCreated)
            return;

        float distance = 0.5f;

        for (float i = _grid.Start.x; i < _grid.End.x; i += distance)
        {
            for (float j = _grid.Start.z; j < _grid.End.z; j += distance)
            {
                Vector3 position = new Vector3(i, _grid.Start.y, j);

                if (IsEmptyGround(position))
                {
                    Grass grass = Instantiate(_grass, position, Quaternion.identity, this.transform);
                    grass.TurnOff();
                    _grassList.Add(grass);
                }
            }
        }

        _isCreated = true;
    }

    public void SetDefaultState()
    {
        foreach (var grass in _grassList)
            grass.TurnOff();
    }


    private bool IsEmptyGround(Vector3 position)
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