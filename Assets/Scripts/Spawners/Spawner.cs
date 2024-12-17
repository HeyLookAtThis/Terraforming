using UnityEngine;

public class Spawner
{
    private LevelBordersMarker _levelBorders;
    private LevelCounter _levelCounter;

    public Spawner(LevelBordersMarker levelBorders, LevelCounter levelCounter)
    {
        _levelBorders = levelBorders;
        _levelCounter = levelCounter;
    }

    protected LevelBordersMarker LevelBorders => _levelBorders;
    protected LevelCounter LevelCounter => _levelCounter;

    protected Vector3 GetRandomPosition(float radius)
    {
        Vector2 randomPosition = radius * Random.insideUnitCircle;
        return new Vector3(_levelBorders.Center.x + randomPosition.x, _levelBorders.Center.y, _levelBorders.Center.z + randomPosition.y);
    }

    protected bool IsWater(Collider collider) => collider.TryGetComponent<Water>(out Water water);
    protected bool IsTree(Collider collider) => collider.TryGetComponent<Tree>(out Tree tree);
    protected bool IsVolkano(Collider collider) => collider.TryGetComponent<Volcano>(out Volcano volcano);
}
