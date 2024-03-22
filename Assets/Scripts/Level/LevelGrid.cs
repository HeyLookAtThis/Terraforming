using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelGenerator))]
public class LevelGrid : MonoBehaviour
{
    [SerializeField] private float _edgeOffset;
    [SerializeField] private float _yAxisValue;
    [SerializeField] private Terrain _terrain;
    
    private LevelGenerator _levelGenerator;

    private List<Vector3> _cellCoordinates;
    private List<Vector3> _usedCoordinates;

    private Vector3 _startingCoordinate;
    private Vector3 _endingCoordinate;

    public Vector3 Start => _startingCoordinate;

    public Vector3 End => _endingCoordinate;

    private void Awake()
    {
        _levelGenerator = GetComponent<LevelGenerator>();
        SetLevelBoundaries();
        Initialize();
    }

    private void OnEnable()
    {
        _levelGenerator.Launched += ReturnToDefault;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= ReturnToDefault;
    }

    public Vector3 GetRandomCellCoordinate()
    {
        if (_cellCoordinates.Count > 0)
        {
            Vector3 coordinate = _cellCoordinates[Random.Range(0, _cellCoordinates.Count)];
            _usedCoordinates.Add(coordinate);
            _cellCoordinates.Remove(coordinate);
            return coordinate;
        }

        return Vector3.zero;
    }

    public Vector3 GetRandomCoordinate()
    {
        return new Vector3(Random.Range(_startingCoordinate.x, _endingCoordinate.x), _yAxisValue, Random.Range(_startingCoordinate.z, _endingCoordinate.z));
    }

    private void ReturnToDefault()
    {
        _cellCoordinates.AddRange(_usedCoordinates);
        _usedCoordinates.Clear();
    }

    private void Initialize()
    {
        _cellCoordinates = new List<Vector3>();
        _usedCoordinates = new List<Vector3>();
        float cellSize = _edgeOffset * 2;

        for (float i = _startingCoordinate.x + cellSize; i < _endingCoordinate.x - cellSize; i += cellSize)
            for (float j = _startingCoordinate.z + cellSize; j < _endingCoordinate.z - cellSize; j += cellSize)
                _cellCoordinates.Add(new Vector3(i, _yAxisValue, j));
    }

    private void SetLevelBoundaries()
    {
        _startingCoordinate = new Vector3(_edgeOffset, _yAxisValue, _edgeOffset);
        _endingCoordinate = new Vector3(_terrain.terrainData.size.x - _edgeOffset, _yAxisValue, _terrain.terrainData.size.z - _edgeOffset);
    }
}