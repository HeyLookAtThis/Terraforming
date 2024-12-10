using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private LevelBoundariesMarker _marker;

    public Spawner(LevelBoundariesMarker marker)
    {
        _marker = marker;
    }

    protected Vector3 GetRandomPosition()
    => new Vector3(Random.Range(_marker.StartingCoordinate.x, _marker.EndingCoordinate.x), _marker.YAxisValue, Random.Range(_marker.StartingCoordinate.z, _marker.EndingCoordinate.z));

    protected bool IsWater(Collider collider) => collider.TryGetComponent<Water>(out Water water);
    protected bool IsTree(Collider collider) => collider.TryGetComponent<Tree>(out Tree tree);
    protected bool IsVolkano(Collider collider) => collider.TryGetComponent<Volcano>(out Volcano volcano);
}
