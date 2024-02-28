using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class VolcanoesCreator : ObjectsInstantiator
{
    [SerializeField] private Volcano _prefab;
    [SerializeField] private Ground _ground;

    public override void Create(uint currentLevel)
    {
        int count = (int)currentLevel;

        while (count > 0)
        {
            Volcano volcano = Instantiate(_prefab, GetAllowedCoordinate(), Quaternion.identity, this.transform);
            volcano.BeginHeatGround(_ground);
            AddInteractionObject(volcano);
            count--;
        }
    }
}