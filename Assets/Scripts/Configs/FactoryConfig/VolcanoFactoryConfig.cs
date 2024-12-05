using System;
using UnityEngine;

[Serializable]
public class VolcanoFactoryConfig
{
    [field: SerializeField] public Volcano Prefab { get; private set; }
}