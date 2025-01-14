using UnityEngine;
using UnityEngine.Events;

public class GrassPainter
{
    private const int GroundLayerIndex = 0;
    private const int GrassLayerIndex = 1;

    private LevelBordersMarker _marker;
    private Terrain _terrain;

    private float[,,] _map;

    private Vector3 _previousPosition;
    private UnityAction _worked;

    public GrassPainter(Terrain terrain, LevelBordersMarker marker)
    {
        _terrain = terrain;
        _marker = marker;

        InitializeMap();
        ClearMap();
    }

    public event UnityAction Worked
    {
        add => _worked += value;
        remove => _worked -= value;
    }

    private int CoordinatesOrigin => 0;
    private float ShadedValue => 1f;
    private float TransparentValue => 0f;
    private float Speed => 2f;

    public void Draw(Vector3 position, int radius, MonoBehaviour monoBehaviour)
    {
        if (position == _previousPosition || _marker.IsUnderWater(position))
            return;

        Vector2 convertedPosition = GetConvertedPosition(position);

        for (int x = (int)convertedPosition.x - radius; x < (int)convertedPosition.x + radius; x++)
        {
            for (int y = (int)convertedPosition.y - radius; y < (int)convertedPosition.y + radius; y++)
            {
                Vector2 currentPosition = new Vector2(x, y);
                float pixelDistance = Vector2.Distance(currentPosition, convertedPosition);
                float normalizedValue = ShadedValue - pixelDistance / radius;

                var normX = x * 1.0f / (_terrain.terrainData.alphamapWidth - 1);
                var normY = y * 1.0f / (_terrain.terrainData.alphamapHeight - 1);

                var angle = _terrain.terrainData.GetSteepness(normX, normY);

                if (pixelDistance <= radius && _marker.IsIncludedInLevel(new Vector2(position.z, position.x)))
                {
                    if (_map[x, y, GrassLayerIndex] < ShadedValue && angle == 0)
                    {
                        if (monoBehaviour.GetType() == typeof(Cloud))
                            _worked?.Invoke();

                        _map[x, y, GrassLayerIndex] += normalizedValue * Speed;
                        _map[x, y, GroundLayerIndex] -= normalizedValue * Speed;
                    }
                }
            }
        }

        _previousPosition = position;
        _terrain.terrainData.SetAlphamaps(CoordinatesOrigin, CoordinatesOrigin, _map);
    }

    public void ClearMap()
    {
        for (int y = 0; y < _terrain.terrainData.alphamapHeight; y++)
        {
            for (int x = 0; x < _terrain.terrainData.alphamapWidth; x++)
            {
                _map[x, y, GroundLayerIndex] = ShadedValue;
                _map[x, y, GrassLayerIndex] = TransparentValue;
            }
        }

        _terrain.terrainData.SetAlphamaps(CoordinatesOrigin, CoordinatesOrigin, _map);
    }

    private void InitializeMap() => _map = new float[_terrain.terrainData.alphamapWidth, _terrain.terrainData.alphamapHeight, _terrain.terrainData.alphamapLayers];

    private Vector2 GetConvertedPosition(Vector3 position)
    {
        float convertedCoefficient = 10f;
        Vector2 convertedPosition = new Vector2(position.z, position.x) * convertedCoefficient;
        return convertedPosition;
    }
}
