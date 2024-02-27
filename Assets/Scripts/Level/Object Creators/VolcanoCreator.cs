using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VolcanoCreator : ObjectsInstantiator
{
    [SerializeField] private Volcano _prefab;

    private List<Volcano> _objects = new List<Volcano>();

    public int ObjectsCount => _objects.Count;

    public IReadOnlyList<Volcano> Objects => _objects;

    public override void Create(uint currentLevel)
    {
        int count = (int)currentLevel;

        while (count > 0)
        {
            Volcano newVolcano = Instantiate(_prefab, GetAllowedCoordinate(), Quaternion.identity, this.transform);
            newVolcano.Initialize(GetComponent<Ground>());
            _objects.Add(newVolcano);

            count--;

            if (count == 0)
                break;
        }
    }

    public override void SetDefaultState()
    {
        if (_objects != null)
        {
            foreach (var volcano in _objects)
                volcano.Destroy();

            _objects.Clear();
        }
    }
}