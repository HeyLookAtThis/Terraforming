using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IInteractiveObject
{
    private bool _usedByPlayer;

    public bool UsedByPlayer => _usedByPlayer;

    public Transform Transform { get => transform; set => transform.position = value.position; }

    private void OnEnable()
    {
        gameObject.isStatic = true;
        _usedByPlayer = false;
        SetDefaultState();
    }

    public abstract void ReactToScanner();
    public abstract void SetDefaultState();
    public void Destroy() => Destroy(gameObject);

    protected void TurnOnUsed()
    {
        if (_usedByPlayer == false)
            _usedByPlayer = true;
    }

    protected void TurnOffUsed() => _usedByPlayer = false;
}
