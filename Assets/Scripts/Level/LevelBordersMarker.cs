using UnityEngine;

public class LevelBordersMarker
{
    private float _radius;
    private Vector3 _center;
    private LevelBordersConfig _config;

    public LevelBordersMarker(Terrain terrain, LevelConfig config)
    {
        _radius = config.MarkerConfig.DistanceToEnd;
        _center = config.MarkerConfig.Center;
        _config = config.MarkerConfig;
    }

    public LevelBordersConfig Config => _config;
    public float GroundHeight => 1f;
    public float WaterRadius => 5f;
    public Vector3 Center => _center;
    public float Radius => _radius;

    public bool IsIncludedInLevel(Vector2 coordinate) => Vector2.Distance(coordinate, new Vector2(_center.x, _center.z)) <= _radius;
}
