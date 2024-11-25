using System;
using UnityEngine;

[Serializable]
public class CloudWateringConfig
{
    [field: SerializeField, Range(5, 15)] public int Radius { get; private set; }
    [field: SerializeField, Range(5, 10)] public float WateringTime { get; private set; }
}
