using UnityEngine;

public class SnowflakeSpawner
{
    private SnowflakeFactory _factory;
    private TreeSpawner _treeSpawner;
    private LevelBordersMarker _marker;

    public SnowflakeSpawner(SnowflakeFactory factory, TreeSpawner treeSpawner, LevelBordersMarker marker)
    {
        _factory = factory;
        _treeSpawner = treeSpawner;
        _marker = marker;
    }

    public void Run()
    {
        for (int i = 0; i < _factory.Storage.Count; i++)
        {
            IInteractiveObject snowflake = _factory.Storage.GetObjectTransform(i);
            snowflake.Transform.position = GetAllowedRandomPosition(i);
        }
    }

    private Vector3 GetAllowedRandomPosition(int treeIndex)
    {
        Vector3 treePosition = GetTree(treeIndex).Transform.position;
        Vector3 position = GetRandomCoordinateNearTree(treePosition);
        bool isSuccess = false;

        while (isSuccess == false)
        {
            Physics.Raycast(treePosition + Vector3.up, Vector3.down, out RaycastHit hit);

            if (hit.collider.TryGetComponent<Water>(out Water water) || position == treePosition || _marker.IsIncludedInLevel(new Vector2(position.x, position.z)) == false)
                position = GetRandomCoordinateNearTree(treePosition);
            else
                isSuccess = true;
        }

        return position;
    }

    private Vector3 GetRandomCoordinateNearTree(Vector3 treePosition)
    {
        int distance = 2;
        Vector2 randomPositionInsideCircle = Random.insideUnitCircle * distance;
        return new Vector3(treePosition.x + randomPositionInsideCircle.x, treePosition.y, treePosition.z + randomPositionInsideCircle.y);
    }

    private IInteractiveObject GetTree(int treeIndex) => _treeSpawner.GetTansform(treeIndex);
}
