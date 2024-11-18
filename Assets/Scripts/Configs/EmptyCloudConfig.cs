using System;
using UnityEngine;

[Serializable]
public class EmptyCloudConfig
{
    [field: SerializeField, Range(1.6f, 3)] public float MaxDistanceToTarget { get; private set; }
    [field: SerializeField, Range(0.1f, 1.5f)] public float MinDistanceToTarget { get; private set; }
}
