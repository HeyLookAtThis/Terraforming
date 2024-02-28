using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private float _edgeOffset;
    [SerializeField] private float _yAxisValue;
    [SerializeField] private Terrain _terrain;

    private List<Vector3> _cellCoordinates;

    private Vector3 _startingCoordinate;
    private Vector3 _endingCoordinate;

    public Vector3 Start => _startingCoordinate;

    public Vector3 End => _endingCoordinate;

    private void Awake()
    {
        SetLevelBoundaries();
        Initialize();
    }

    public Vector3 GetRandomCellCoordinate()
    {
        if (_cellCoordinates.Count > 0)
        {
            Vector3 coordinate = _cellCoordinates[Random.Range(0, _cellCoordinates.Count)];
            _cellCoordinates.Remove(coordinate);
            return coordinate;
        }

        return Vector3.zero;
    }

    public Vector3 GetRandomCoordinate()
    {
        return new Vector3(Random.Range(_startingCoordinate.x, _endingCoordinate.x), _yAxisValue, Random.Range(_startingCoordinate.z, _endingCoordinate.z));
    }

    private void Initialize()
    {
        _cellCoordinates = new List<Vector3>();
        float cellSize = _edgeOffset * 2;

        for (float i = _startingCoordinate.x; i < _endingCoordinate.x; i += cellSize)
            for (float j = _startingCoordinate.z; j < _endingCoordinate.z; j += cellSize)
                _cellCoordinates.Add(new Vector3(i, _yAxisValue, j));
    }

    private void SetLevelBoundaries()
    {
        _startingCoordinate = new Vector3(_edgeOffset, _yAxisValue, _edgeOffset);
        _endingCoordinate = new Vector3(_terrain.terrainData.size.x - _edgeOffset, _yAxisValue, _terrain.terrainData.size.z - _edgeOffset);
    }
}