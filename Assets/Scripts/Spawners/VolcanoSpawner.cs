using System.Linq;
using UnityEngine;

public class VolcanoSpawner : Spawner
{
    private VolcanoStorage _storage;
    private CircleCoordinateSystem _cellsSystem;

    public VolcanoSpawner(LevelBordersMarker levelBorders, LevelCounter levelCounter, VolcanoStorage storage, CircleCoordinateSystem cellsSystem) : base(levelBorders, levelCounter)
    {
        _storage = storage;
        _cellsSystem = cellsSystem;
    }

    public void Run()
    {
        for (int i = 0; i < _storage.Count; i++)
        {
            IInteractiveObject volcano = _storage.GetObjectTransform(i);
            _cellsSystem.PlaceObject(volcano, LevelCounter.CurrentLevel);
            volcano.Transform.LookAt(LevelBorders.Center);
        }
    }

    private Vector3 GetAllowedRandomPosition()
    {
        float distancePerLevel = 2.8f;
        float convertOuterRadius = LevelBorders.WaterRadius + LevelCounter.CurrentLevel * distancePerLevel;
        Vector3 position = GetRandomPosition(convertOuterRadius);

        bool isSuccess = false;
        float radius = 2.5f;

        while (isSuccess == false)
        {
            var colliders = Physics.OverlapSphere(position, radius);

            var collider = colliders.FirstOrDefault(collider => IsWater(collider) || IsTree(collider) || IsVolkano(collider));

            if (collider == null)
                isSuccess = true;
            else
                position = GetRandomPosition(convertOuterRadius);
        }

        return position;
    }
}
