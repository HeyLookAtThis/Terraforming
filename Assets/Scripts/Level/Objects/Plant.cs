using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public bool IsGreen { get; private set; } = false;

    private void Awake()
    {
        gameObject.isStatic = true;
    }

    public abstract void MakeGreen();

    public void TurnOnGreen()
    {
        IsGreen = true;
    }

    public void TurnOffGreen()
    {
        IsGreen = false;
    }
}