using UnityEngine;

[RequireComponent(typeof(PlayerColliderChecker),typeof(PlayerObjectsCounter),typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public PlayerColliderChecker ColliderChecker => GetComponent<PlayerColliderChecker>();

    public PlayerObjectsCounter Counter => GetComponent<PlayerObjectsCounter>();

    public PlayerMovement Movement => GetComponent<PlayerMovement>();

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void InitializeReservoir(CloudReservoir reservoir)
    {
        GetComponent<PlayerWaterIsOverTransition>().InitializeReservoir(reservoir);
    }
}
