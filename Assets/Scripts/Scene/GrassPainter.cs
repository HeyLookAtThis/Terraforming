using UnityEngine;
using UnityEngine.Events;

public class GrassPainter
{
    private const int GroundLayerIndex = 0;
    private const int GrassLayerIndex = 1;

    private Terrain _terrain;
    private Cloud _cloud;
    private int _radius;

    private float[,,] _map;

    private bool _isDrawing;

    private UnityAction<bool> _drawing;

    public GrassPainter(Terrain terrain, Cloud cloud)
    {
        _radius = cloud.Config.CloudWateringConfig.GrassPainterRadius;
        _terrain = terrain;
        _cloud = cloud;

        InitializeCurrentMap();
        ClearMap();
    }

    public event UnityAction<bool> Drawing
    {
        add => _drawing += value;
        remove => _drawing -= value;
    }

    private int CoordinatesOrigin => 0;
    private float TransparentValue => 0f;
    private float ShadedValue => 1f;

    public void Draw()
    {
        Vector2 convertedCloudPosition = GetConvertedCloudPosition();

        for (int x = (int)convertedCloudPosition.x - _radius; x < (int)convertedCloudPosition.x + _radius; x++)
        {
            for (int y = (int)convertedCloudPosition.y - _radius; y < (int)convertedCloudPosition.y + _radius; y++)
            {
                Vector2 currentPosition = new Vector2(x, y);
                float pixelDistance = Vector2.Distance(currentPosition, convertedCloudPosition);
                float normalizedValue = ShadedValue - pixelDistance / _radius;

                var normX = x * 1.0f / (_terrain.terrainData.alphamapWidth - 1);
                var normY = y * 1.0f / (_terrain.terrainData.alphamapHeight - 1);

                var angle = _terrain.terrainData.GetSteepness(normX, normY);

                if (pixelDistance <= _radius)
                {
                    if (_map[x, y, GrassLayerIndex] < ShadedValue && angle == 0)
                    {
                        _map[x, y, GrassLayerIndex] += normalizedValue;
                        _isDrawing = true;
                    }
                    else
                    {
                        _isDrawing = false;
                    }
                }
            }
        }

        _drawing?.Invoke(_isDrawing);
        _terrain.terrainData.SetAlphamaps(CoordinatesOrigin, CoordinatesOrigin, _map);
    }

    public void ClearMap()
    {
        for (int y = 0; y < _terrain.terrainData.alphamapHeight; y++)
            for (int x = 0; x < _terrain.terrainData.alphamapWidth; x++)
                _map[x, y, GroundLayerIndex] = ShadedValue;
    }

    private void InitializeCurrentMap() => _map = new float[_terrain.terrainData.alphamapWidth, _terrain.terrainData.alphamapHeight, _terrain.terrainData.alphamapLayers];

    private Vector2 GetConvertedCloudPosition()
    {
        float convertedCoefficient = 10f;
        Vector2 convertedPosition = new Vector2(_cloud.transform.position.z, _cloud.transform.position.x) * convertedCoefficient;

        return convertedPosition;
    }
}
