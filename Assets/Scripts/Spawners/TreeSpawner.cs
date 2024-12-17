using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreeSpawner : Spawner
{
    private TreeFactory _factory;
    private List<IInteractiveObject> _positions;

    public TreeSpawner(LevelBordersMarker levelBorders, LevelCounter levelCounter, TreeFactory treeFactory) : base(levelBorders, levelCounter)
    {
        _factory = treeFactory;
        _positions = new List<IInteractiveObject>();
    }

    public IReadOnlyList<IInteractiveObject> Positions => _positions;

    public void Run()
    {
        for (int i = 0; i < _factory.Storage.Count; i++)
        {
            IInteractiveObject tree = _factory.Storage.GetObjectTransform(i);
            tree.Transform.position = GetAllowedRandomPosition();
            _positions.Add(tree);
        }
    }

    public IInteractiveObject GetTansform(int index) => Positions[index];

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
