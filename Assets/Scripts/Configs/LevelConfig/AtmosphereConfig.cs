using System;
using UnityEngine;

[Serializable]
public class AtmosphereConfig
{
    [field: SerializeField, Range(10, 50)] public int TimeToReachMaxTemperature { get; private set; }
}
