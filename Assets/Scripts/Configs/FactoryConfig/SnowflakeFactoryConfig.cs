using System;
using UnityEngine;

[Serializable]
public class SnowflakeFactoryConfig
{
    [field: SerializeField] public Snowflake Prefab { get; private set; }
}
