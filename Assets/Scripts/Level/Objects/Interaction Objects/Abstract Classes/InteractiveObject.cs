using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    private bool _usedByPlayer;

    public bool UsedByPlayer => _usedByPlayer;

    protected virtual void Awake()
    {
        gameObject.isStatic = true;
        TurnOffUsed();
    }

    public virtual void ReactToScanner() { }

    public virtual void ReturnToDefaultState() => TurnOffUsed();

    protected void TurnOnUsed()
    {
        if (_usedByPlayer != true)
            _usedByPlayer = true;
    }

    protected void TurnOffUsed()
    {
        if (_usedByPlayer != false)
            _usedByPlayer = false;
    }
}
