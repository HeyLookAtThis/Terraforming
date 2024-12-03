using UnityEngine;

public class Coin : Loot, IInteractiveObject
{
    public Transform Transform { get => transform; set => transform.position = value.position; }
}
