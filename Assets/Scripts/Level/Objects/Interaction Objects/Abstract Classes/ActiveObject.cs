using UnityEngine;

public abstract class ActiveObject : MonoBehaviour
{
    private bool _wasUsedByPlayer;

    public bool WasUsedByPlayer => _wasUsedByPlayer;

    protected virtual void Awake()
    {
        gameObject.isStatic = true;
        TurnOffUsed();
    }

    public abstract void ReactToScanner(Player player);

    public abstract void ReturnToDefaultState();

    protected void TurnOnUsed()
    {
        if (_wasUsedByPlayer != true)
            _wasUsedByPlayer = true;
    }

    protected void TurnOffUsed()
    {
        if (_wasUsedByPlayer != false)
            _wasUsedByPlayer = false;
    }
}
