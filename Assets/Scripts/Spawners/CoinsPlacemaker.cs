using UnityEngine;

public class CoinsPlacemaker
{
    private CoinsStorage _storage;
    private LevelBordersMarker _levelBorders;

    public CoinsPlacemaker(LevelBordersMarker levelBorders, CoinsStorage storage)
    {
        _storage = storage;
        _levelBorders = levelBorders;
    }

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
        Vector3 position = GetRandomPosition(_levelBorders.Radius);
        bool isSuccess = false;

        while (isSuccess == false)
        {
            Physics.Raycast(position + Vector3.up, Vector3.down, out RaycastHit hit);

            if (IsWater(hit.collider))
                position = GetRandomPosition(_levelBorders.Radius);
            else
                isSuccess = true;
        }

        return position;
    }

    private Vector3 GetRandomPosition(float radius)
    {
        Vector2 randomPosition = radius * Random.insideUnitCircle;
        return new Vector3(_levelBorders.Center.x + randomPosition.x, _levelBorders.Center.y, _levelBorders.Center.z + randomPosition.y);
    }

    private bool IsWater(Collider collider) => collider.TryGetComponent<Water>(out Water water);

}
