using UnityEngine;

public abstract class Plant : MonoBehaviour
{
    public bool IsGreen { get; private set; } = false;

    protected virtual void Awake()
    {
        gameObject.isStatic = true;
    }

    public abstract void MakeGreen();

    public virtual void TurnOffGreen()
    {
        IsGreen = false;
    }

    public void TurnOnGreen()
    {
        IsGreen = true;
    }
}