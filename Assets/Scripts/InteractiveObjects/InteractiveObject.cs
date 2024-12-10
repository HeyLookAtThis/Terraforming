using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IInteractiveObject
{
    private bool _usedByPlayer;

    public bool UsedByPlayer => _usedByPlayer;

    public Transform Transform { get => transform; set => transform.position = value.position; }

    protected virtual void Awake()
    {
        gameObject.isStatic = true;
        _usedByPlayer = false;
    }

    public virtual void ReactToScanner() { }

    public virtual void ReturnToDefaultState() => TurnOffUsed();

    protected void TurnOnUsed()
    {
        if (_usedByPlayer == false)
            _usedByPlayer = true;
    }

    protected void TurnOffUsed()
    {
        if (_usedByPlayer == true)
            _usedByPlayer = false;
    }
}
