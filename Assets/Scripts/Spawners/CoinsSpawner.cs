using UnityEngine;

public class CoinsSpawner : Spawner
{
    private CoinsFactory _factory;

    public CoinsSpawner(LevelBordersMarker levelBorders, LevelCounter levelCounter, CoinsFactory factory) : base(levelBorders, levelCounter) => _factory = factory;

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
        Vector3 position = GetRandomPosition(LevelBorders.Radius);
        bool isSuccess = false;

        while (isSuccess == false)
        {
            Physics.Raycast(position + Vector3.up, Vector3.down, out RaycastHit hit);

            if (IsWater(hit.collider))
                position = GetRandomPosition(LevelBorders.Radius);
            else
                isSuccess = true;
        }

        return position;
    }
}
