using UnityEngine;

public class LevelBoundariesMarker
{
    private float _offset;

    private Vector3 _startingCoordinate;
    private Vector3 _endingCoordinate;

    public LevelBoundariesMarker(Terrain terrain, LevelConfig config)
    {
        _offset = config.MarkerConfig.Offset;
        Vector3 terrainPosition = GetTerrainPosition(terrain);
        _startingCoordinate = GetStartingCoordinate(terrainPosition);
        _endingCoordinate = GetEndingPosition(terrainPosition, terrain);
    }

    public Vector3 StartingCoordinate => _startingCoordinate;
    public Vector3 EndingCoordinate => _endingCoordinate;
    public float YAxisValue => 1f;

    public bool IsIncludedInLevel(Vector2 coordinate) => coordinate.x >= _startingCoordinate.x && coordinate.y >= _startingCoordinate.z && coordinate.x <= _endingCoordinate.x && coordinate.y <= _endingCoordinate.z;

    private Vector3 GetTerrainPosition(Terrain terrain) => terrain.GetPosition();
    private Vector3 GetStartingCoordinate(Vector3 terrainPosition) => new Vector3(terrainPosition.x + _offset, YAxisValue, terrainPosition.z + _offset);
    private Vector3 GetEndingPosition(Vector3 terrainPosition, Terrain terrain) => new Vector3(terrainPosition.x + terrain.terrainData.size.x - _offset, YAxisValue, terrainPosition.z + terrain.terrainData.size.z - _offset);
}
