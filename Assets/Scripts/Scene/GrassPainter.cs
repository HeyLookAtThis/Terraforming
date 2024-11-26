using UnityEngine;

public class GrassPainter
{
    private const int GroundLayerIndex = 0;
    private const int GrassLayerIndex = 1;

    private Terrain _terrain;
    private Cloud _cloud;
    private int _radius;

    private float[,,] _groundMap;
    private float[,,] _currentMap;

    public GrassPainter(Terrain terrain, Cloud cloud)
    {
        _radius = cloud.Config.CloudWateringConfig.GrassPainterRadius;
        _terrain = terrain;
        _cloud = cloud;

        InitializeGroundMap();
        ClearMap();
    }

    private int CoordinatesOrigin => 0;
    private float TransparentValue => 0f;
    private float ShadedValue => 1f;

    public void Draw()
    {
        float[,,] map = _currentMap;

        Vector2 convertedCloudPosition = GetConvertedCloudPosition();

        for (int x = (int)convertedCloudPosition.x - _radius; x < (int)convertedCloudPosition.x + _radius; x++)
        {
            for (int y = (int)convertedCloudPosition.y - _radius; y < (int)convertedCloudPosition.y + _radius; y++)
            {
                Vector2 currentPosition = new Vector2(x, y);
                float pixelDistance = Vector2.Distance(currentPosition, convertedCloudPosition);
                float normalizedValue = ShadedValue - pixelDistance / _radius;

                if (pixelDistance <= _radius)
                    if (map[x, y, GrassLayerIndex] != ShadedValue)
                        map[x, y, GrassLayerIndex] += normalizedValue;
            }
        }

        _terrain.terrainData.SetAlphamaps(CoordinatesOrigin, CoordinatesOrigin, map);
        _currentMap = map;
    }

    public void ClearMap()
    {
        _terrain.terrainData.SetAlphamaps(CoordinatesOrigin, CoordinatesOrigin, _groundMap);
        _currentMap = _groundMap;
    }

    private void InitializeGroundMap()
    {
        _groundMap = new float[_terrain.terrainData.alphamapWidth, _terrain.terrainData.alphamapHeight, _terrain.terrainData.alphamapLayers];

        for (int y = 0; y < _terrain.terrainData.alphamapHeight; y++)
            for (int x = 0; x < _terrain.terrainData.alphamapWidth; x++)
                _groundMap[x, y, GroundLayerIndex] = ShadedValue;
    }

    private Vector2 GetConvertedCloudPosition()
    {
        float convertedCoefficient = 10f;
        Vector2 convertedPosition = new Vector2(_cloud.transform.position.z, _cloud.transform.position.x) * convertedCoefficient;

        return convertedPosition;
    }
}
