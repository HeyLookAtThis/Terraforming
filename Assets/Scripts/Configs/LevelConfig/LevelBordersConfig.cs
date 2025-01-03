using System;
using UnityEngine;

[Serializable]
public class LevelBordersConfig
{
    [field: SerializeField, Range(5, 10)] public float DistanceToStart { get; private set; }
    [field: SerializeField, Range(20, 25)] public float DistanceToEnd { get; private set; }
    [field: SerializeField, Range(3, 5)] public float DistanceBetweenAxis { get; private set; }
    [field: SerializeField] public Vector3 Center { get; private set; }
}
