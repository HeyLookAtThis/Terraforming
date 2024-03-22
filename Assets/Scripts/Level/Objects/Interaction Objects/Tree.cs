using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Tree : LevelObject
{
    [SerializeField] private float _radius;
    [SerializeField] private GameObject _emptyTrunk;
    [SerializeField] private GameObject _greenTrunk;

    private UnityAction _madeGreen;

    public event UnityAction MadeGreen
    {
        add => _madeGreen += value;
        remove => _madeGreen -= value;
    }

    private void Start()
    {
        SetGreenModel(WasUsedByPlayer);
    }

    public override void ReactToScanner(PlayerObjectsCounter player)
    {
        MakeGreen(player);
    }

    public override void ReturnToDefaultState()
    {
        Destroy(gameObject);
    }

    private void MakeGreen(PlayerObjectsCounter player)
    {
        if (WasUsedByPlayer == false)
        {
            TurnOnUsed();
            SetGreenModel(WasUsedByPlayer);
            UseObjectsAround(player);
            _madeGreen?.Invoke();
        }
    }

    public void SetGreenModel(bool isGreen)
    {
        _emptyTrunk.SetActive(!isGreen);
        _greenTrunk.SetActive(isGreen);
    }

    private void UseObjectsAround(PlayerObjectsCounter player)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
            if (collider.TryGetComponent<LevelObject>(out LevelObject interationObject))
                interationObject.ReactToScanner(player);
    }
}