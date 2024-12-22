using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Loot : InteractiveObject
{
    [SerializeField] private float _moveToTargetSpeed;
    [SerializeField] private LootView _view;

    private SphereCollider _sphereCollider;
    private Coroutine _playerChaser;

    protected override void Awake()
    {
        base.Awake();
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

    private void OnTriggerEnter(Collider other)
    {
        if (_view.IsAllowed && UsedByPlayer == false)
        {
            if (other.TryGetComponent<Character>(out Character player))
            {
                MoveToCharacter(player.transform.position);                
                _view.PlaySound();
                player.LootCounter.Add(this);
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