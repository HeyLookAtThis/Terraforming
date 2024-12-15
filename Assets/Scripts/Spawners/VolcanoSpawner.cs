using UnityEngine;

public class VolcanoSpawner
{
    private VolcanoFactory _factory;
    private LevelBoundariesMarker _levelMarker;
    private Transform _characterSpawnPoint;

    public VolcanoSpawner(VolcanoFactory factory, LevelBoundariesMarker levelMarker, Transform characterSpawnPoint)
    {
        _factory = factory;
        _levelMarker = levelMarker;
        _characterSpawnPoint = characterSpawnPoint;
    }

    public void Run()
    {
        for (int i = 0; i < _factory.Storage.Count; i++)
        {
            IInteractiveObject volcano = _factory.Storage.GetObjectTransform(i);
            volcano.Transform.position = GetAllowedRandomPosition();
            volcano.Transform.LookAt(_characterSpawnPoint);
        }
    }

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
        => new Vector3(Random.Range(_levelMarker.StartingCoordinate.x, _levelMarker.EndingCoordinate.x), _levelMarker.YAxisValue, Random.Range(_levelMarker.StartingCoordinate.z, _levelMarker.EndingCoordinate.z));

    private bool IsWater(Collider collider) => collider.TryGetComponent<Water>(out Water water);
    private bool IsTree(Collider collider) => collider.TryGetComponent<Tree>(out Tree tree);
    private bool IsVolkano(Collider collider) => collider.TryGetComponent<Volcano>(out Volcano volcano);
}
