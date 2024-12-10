using UnityEngine;

public class CoinsSpawner
{
    private CoinsFactory _factory;
    private LevelBoundariesMarker _marker;

    public CoinsSpawner(CoinsFactory factory, LevelBoundariesMarker marker)
    {
        _factory = factory;
        _marker = marker;
    }

    public void Run()
    {
        for (int i = 0; i < _factory.Storage.Count; i++)
        {
            IInteractiveObject coin = _factory.Storage.GetObjectTransform(i);
            coin.Transform.position = GetAllowedRandomPosition();
        }
    }

    private Vector3 GetAllowedRandomPosition()
    {
        Vector3 position = GetRandomPosition();
        bool isSuccess = false;

        while (isSuccess == false)
        {
            Physics.Raycast(position + Vector3.up, Vector3.down, out RaycastHit hit);

            if (hit.collider.TryGetComponent<Water>(out Water water))
                position = GetRandomPosition();
            else
                isSuccess = true;
        }

        return position;
    }

    private Vector3 GetRandomPosition()
        => new Vector3(Random.Range(_marker.StartingCoordinate.x, _marker.EndingCoordinate.x), _marker.YAxisValue, Random.Range(_marker.StartingCoordinate.z, _marker.EndingCoordinate.z));
}
