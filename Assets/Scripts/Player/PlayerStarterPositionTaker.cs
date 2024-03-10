using DG.Tweening;
using UnityEngine;

public class PlayerStarterPositionTaker : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Water _water;

    private PlayerColliderChecker _colliderChecker;
    private PlayerSatOnCloudState _satOnCloudState;
    private Vector3 _coordinates;

    private void Awake()
    {
        _colliderChecker = GetComponent<PlayerColliderChecker>();
        _satOnCloudState = GetComponent<PlayerSatOnCloudState>();

        float height = 4f;
        _coordinates = new Vector3(_water.transform.position.x, height, _water.transform.position.z);
    }

    private void OnEnable()
    {
        _levelGenerator.Launched += OnRun;
    }

    private void OnDisable()
    {
        _levelGenerator.Launched -= OnRun;
    }

    private void OnRun(uint currentLevel)
    {
        _colliderChecker.TurnOffGrounded();
        transform.DOMove(_coordinates, 0.1f);
        _satOnCloudState.SatOnCloudInvoke();
    }
}
