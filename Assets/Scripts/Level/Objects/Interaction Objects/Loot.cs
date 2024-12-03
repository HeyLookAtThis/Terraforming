using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class Loot : InteractiveObject
{
    [SerializeField] private float _moveToTargetSpeed;
    [SerializeField] private LootView _view;

    private SphereCollider _sphereCollider;
    private Coroutine _playerChaser;

    private UnityAction<Loot> _foundByPlayer;

    public event UnityAction<Loot> FoundByPlayer
    {
        add => _foundByPlayer += value;
        remove => _foundByPlayer -= value;
    }

    protected override void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
    }

    public override void ReactToScanner()
    {
        base.ReactToScanner();

        if (UsedByPlayer == false)
        {
            gameObject.isStatic = false;
            _view.TurnOnVisible();
        }
    }

    public override void ReturnToDefaultState() 
    {
        base.ReturnToDefaultState();
        _view.TurnOffVisible();
        gameObject.isStatic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_view.IsAllowed && UsedByPlayer == false)
        {
            if (other.TryGetComponent<Character>(out Character player))
            {
                MoveToCharacter(player.transform.position);                
                _view.PlaySound();
                _foundByPlayer?.Invoke(this);
            }
        }
    }

    private void MoveToCharacter(Vector3 target)
    {
        if (_playerChaser != null)
            StopCoroutine(_playerChaser);

        _playerChaser = StartCoroutine(ToCharacterMover(target));
    }

    private IEnumerator ToCharacterMover(Vector3 target)
    {
        float seconds = 0.01f;
        var waitTime = new WaitForSeconds(seconds);

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, seconds * _moveToTargetSpeed);
            yield return waitTime;
        }

        if (transform.position == target)
        {
            _view.TurnOffVisible();
            TurnOnUsed();
            yield break;
        }
    }
}