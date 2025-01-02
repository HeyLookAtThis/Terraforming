using System.Linq;
using UnityEngine;

public class TreeSpawner : Spawner
{
    private TreesStorage _storage;

    public TreeSpawner(LevelBordersMarker levelBorders, LevelCounter levelCounter, TreesStorage treeStorage) : base(levelBorders, levelCounter)
    {
        _storage = treeStorage;
    }

    public void Run()
    {
        for (int i = 0; i < _storage.Count; i++)
        {
            IInteractiveObject tree = _storage.GetObjectTransform(i);
            tree.Transform.position = GetAllowedRandomPosition();
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
