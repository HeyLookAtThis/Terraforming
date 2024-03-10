using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TreesCreator : ObjectsInstantiator
{
    [SerializeField] private Tree _prefab;

    private List<Vector3> _positions = new List<Vector3>();

    private UnityAction<IReadOnlyList<Vector3>> _finished;

    public event UnityAction<IReadOnlyList<Vector3>> OnFinished
    {
        add => _finished += value;
        remove => _finished -= value;
    }

    private IReadOnlyList<Vector3> positions => _positions;

    public override void OnCreate(uint currentLevel)
    {
        base.OnCreate(currentLevel);
        int treeMultiplier = 2;
        int count = (int)currentLevel * treeMultiplier;

        while (count > 0)
        {
            Vector3 position = GetAllowedCoordinate();
            Tree tree = Instantiate(_prefab, position, Quaternion.identity, this.transform);
            AddActiveObject(tree);
            count--;

            if (count <= currentLevel)
                _positions.Add(position);
        }

        _finished?.Invoke(positions);
        wasCreated = true;
    }
}