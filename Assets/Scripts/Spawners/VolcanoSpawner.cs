using System.Linq;
using UnityEngine;

public class VolcanoSpawner : Spawner
{
    private VolcanoFactory _factory;

    public VolcanoSpawner(LevelBordersMarker levelBorders, LevelCounter levelCounter, VolcanoFactory factory) : base(levelBorders, levelCounter) => _factory = factory;

    public void Run()
    {
        for (int i = 0; i < _factory.Storage.Count; i++)
        {
            IInteractiveObject volcano = _factory.Storage.GetObjectTransform(i);
            volcano.Transform.position = GetAllowedRandomPosition();
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
            var colliders = Physics.OverlapCapsule(position, position + Vector3.up * radius, radius);

            var collider = colliders.FirstOrDefault(collider => IsWater(collider) || IsTree(collider) || IsVolkano(collider));

            if (collider == null)
                isSuccess = true;
            else
                position = GetRandomPosition(convertOuterRadius);
        }

        return position;
    }
}
