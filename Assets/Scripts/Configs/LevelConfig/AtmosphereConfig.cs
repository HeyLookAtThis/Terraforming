using System;
using UnityEngine;

[Serializable]
public class AtmosphereConfig
{
    [field: SerializeField, Range(10, 100)] public int TimeToReachMaxTemperature { get; private set; }
}
