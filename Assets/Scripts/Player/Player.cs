using UnityEngine;

[RequireComponent(typeof(CharacterLayerChecker),typeof(PlayerObjectsCounter),typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    public CharacterLayerChecker ColliderChecker => GetComponent<CharacterLayerChecker>();

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
