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
        for(int i=0; i<_factory.Count; i++)
        {
            IInteractiveObject coin = _factory.GetCoin(i);
            coin.Transform.position = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
        => new Vector3(Random.Range(_marker.StartingCoordinate.x, _marker.EndingCoordinate.x), _marker.YAxisValue, Random.Range(_marker.StartingCoordinate.z, _marker.EndingCoordinate.z));
}
