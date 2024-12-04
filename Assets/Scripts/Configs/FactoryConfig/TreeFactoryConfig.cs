using System;
using UnityEngine;

[Serializable]
public class TreeFactoryConfig
{
    [field: SerializeField] public Tree Prefab { get; private set; }
    [field: SerializeField, Range(1, 3)] public int TreesNumberPerLevelMultiplier { get; private set; }
}
