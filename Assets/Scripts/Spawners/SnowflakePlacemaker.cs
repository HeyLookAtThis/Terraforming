using UnityEngine;

public class SnowflakePlacemaker
{
    private SnowflakesStorage _storage;
    private TreesStorage _treeStorage;

    public SnowflakePlacemaker(SnowflakesStorage storage, TreesStorage treeStorage)
    {
        _storage = storage;
        _treeStorage = treeStorage;
    }

    public void Run()
    {
        for (int i = 0; i < _storage.Count; i++)
        {
            IInteractiveObject snowflake = _storage.GetObjectTransform(i);
            snowflake.Transform.position = GetRandomCoordinateNearTree(_treeStorage.GetPosition(i));
        }
    }

    private Vector3 GetRandomCoordinateNearTree(Vector3 treePosition)
    {
        int distance = 2;
        Vector2 randomPositionInsideCircle = Random.insideUnitCircle * distance;
        return new Vector3(treePosition.x + randomPositionInsideCircle.x, treePosition.y, treePosition.z + randomPositionInsideCircle.y);
    }
}
