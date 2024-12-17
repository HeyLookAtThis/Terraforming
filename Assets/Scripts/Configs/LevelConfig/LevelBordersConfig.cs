using System;
using UnityEngine;

[Serializable]
public class LevelBordersConfig
{
    [field: SerializeField,Range(20,25)] public float Radius { get; private set; }
    [field: SerializeField] public Vector3 Center { get; private set; }
}
