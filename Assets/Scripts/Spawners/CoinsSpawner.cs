using UnityEngine;

public class CoinsSpawner : Spawner
{
    private CoinsStorage _storage;

    public CoinsSpawner(LevelBordersMarker levelBorders, LevelCounter levelCounter, CoinsStorage storage) : base(levelBorders, levelCounter) => _storage = storage;

    public void Run()
    {
        for (int i = 0; i < _storage.Count; i++)
        {
            IInteractiveObject coin = _storage.GetObjectTransform(i);
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
