using UnityEngine;

public class TreeSpawner
{
    private TreeFactory _factory;
    private LevelBoundariesMarker _levelMarker;

    public TreeSpawner(TreeFactory treeFactory, LevelBoundariesMarker levelMarker)
    {
        _factory = treeFactory;
        _levelMarker = levelMarker;
    }

    public void Run()
    {
        for (int i = 0; i < _factory.Count; i++)
        {
            IInteractiveObject coin = _factory.GetTree(i);
            coin.Transform.position = GetAllowedRandomPosition();
        }
    }

    private Vector3 GetAllowedRandomPosition()
    {
        Vector3 position = GetRandomPosition();
        bool isSuccess = false;

        while (isSuccess == false)
        {
            var colliders = Physics.OverlapBox(position, Vector3.one);

            foreach (var collider in colliders)
            {
                if (IsWater(collider) || IsTree(collider) || IsVolkano(collider))
                {
                    position = GetRandomPosition();
                    break;
                }
                
                isSuccess = true;
            }
        }

        return position;
    }


    private Vector3 GetRandomPosition()
        => new Vector3(Random.Range(_levelMarker.StartingCoordinate.x, _levelMarker.EndingCoordinate.x), _levelMarker.YAxisValue, Random.Range(_levelMarker.StartingCoordinate.z, _levelMarker.EndingCoordinate.z));

    private bool IsWater(Collider collider) => collider.TryGetComponent<Water>(out Water water);
    private bool IsTree(Collider collider) => collider.TryGetComponent<Tree>(out Tree tree);
    private bool IsVolkano(Collider collider) => collider.TryGetComponent<Volcano>(out Volcano volcano);
}
