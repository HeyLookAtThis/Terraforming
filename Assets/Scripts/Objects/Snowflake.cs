using UnityEngine;

public class Snowflake : Loot, IInteractiveObject
{
    public Transform Transform { get => transform; set => transform.position = value.position; }
}