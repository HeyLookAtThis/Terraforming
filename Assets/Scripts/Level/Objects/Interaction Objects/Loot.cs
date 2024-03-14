using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Loot : LevelObject
{
    [SerializeField] private float _chaseSpeed;

    private SphereCollider _sphereCollider;
    private Coroutine _playerChaser;
    private LootView _view;

    protected override void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        _view = GetComponentInChildren<LootView>();

        _sphereCollider.isTrigger = true;
    }

    private void AddReward(PlayerObjectsCounter player)
    {
        player.UseObject(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_view.IsAllowed && !WasUsedByPlayer)
        {
            if (other.TryGetComponent<PlayerObjectsCounter>(out PlayerObjectsCounter player))
            {
                ChaseThePlayer(player.transform.position);
                AddReward(player);
                _view.PlaySound();
            }
        }
    }

    private void ChaseThePlayer(Vector3 target)
    {
        if (_playerChaser != null)
            StopCoroutine(_playerChaser);

        _playerChaser = StartCoroutine(PlayerChaser(target));
    }

    private IEnumerator PlayerChaser(Vector3 target)
    {
        float seconds = 0.01f;
        var waitTime = new WaitForSeconds(seconds);

        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, seconds * _chaseSpeed);
            yield return waitTime;
        }

        if (transform.position == target)
        {
            _view.TurnOffVisible();
            TurnOnUsed();
            yield break;
        }
    }

    public override void ReactToScanner(PlayerObjectsCounter player)
    {
        if (!WasUsedByPlayer)
            _view.TurnOnVisible();
    }

    public override void ReturnToDefaultState()
    {
        Destroy(gameObject);
    }
}