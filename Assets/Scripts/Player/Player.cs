using UnityEngine;

[RequireComponent(typeof(CharacterColliderChecker),typeof(PlayerObjectsCounter),typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public CharacterColliderChecker ColliderChecker => GetComponent<CharacterColliderChecker>();

    public PlayerObjectsCounter Counter => GetComponent<PlayerObjectsCounter>();

    public PlayerMovement Movement => GetComponent<PlayerMovement>();

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void InitializeReservoir(CloudReservoir reservoir)
    {
        //GetComponent<PlayerWaterIsOverTransition>().InitializeReservoir(reservoir);
    }
}
