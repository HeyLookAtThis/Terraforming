using System;
using UnityEngine;

[Serializable]
public class EmptyCloudConfig
{
    [field: SerializeField, Range(0.5f, 3)] public float DistanceToTarget { get; private set; }
    [field: SerializeField, Range(1f, 10)] public float Speed { get; private set; }
}
