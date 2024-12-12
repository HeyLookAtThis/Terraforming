using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner
{
    private TreeFactory _factory;
    private LevelBoundariesMarker _marker;
    private List<IInteractiveObject> _positions;

    public TreeSpawner(TreeFactory treeFactory, LevelBoundariesMarker levelMarker)
    {
        _factory = treeFactory;
        _marker = levelMarker;
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
        Vector3 position = GetRandomPosition();
        bool isSuccess = false;
        float radius = 3f;

        while (isSuccess == false)
        {
            var colliders = Physics.OverlapSphere(position, radius);

            foreach (var collider in colliders)
            {
                if (IsWater(collider) || IsTree(collider) || IsVolkano(collider))
                    position = GetRandomPosition();
                else
                    isSuccess = true;
            }
        }

            return position;
    }


    private Vector3 GetRandomPosition()
        => new Vector3(Random.Range(_marker.StartingCoordinate.x, _marker.EndingCoordinate.x), _marker.YAxisValue, Random.Range(_marker.StartingCoordinate.z, _marker.EndingCoordinate.z));

    private bool IsWater(Collider collider) => collider.TryGetComponent<Water>(out Water water);
    private bool IsTree(Collider collider) => collider.TryGetComponent<Tree>(out Tree tree);
    private bool IsVolkano(Collider collider) => collider.TryGetComponent<Volcano>(out Volcano volcano);
}
