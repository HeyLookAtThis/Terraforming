using System.Collections;
using UnityEngine;
using Zenject;

public class Trainer : MonoBehaviour
{
    [SerializeField] private TrainerTargetMediator _targetMediator;
    [SerializeField] private TrainerCameraActivator _cameraActivator;
    [SerializeField] private Arrow _arrow;

    private Coroutine _deactivator;
    private LevelCounter _levelCounter;

    private void OnEnable()
    {
        if (_levelCounter.IsFirstLevel)
        {
            Activate();
            _arrow.Activate();
        }

        _targetMediator.WasWorked += OnDeactivate;
    }

    private void OnDisable()
    {
        _targetMediator.WasWorked -= OnDeactivate;
    }

    private void OnDeactivate() 
    {
        if (_deactivator != null)
            StopCoroutine(_deactivator);

        _deactivator = StartCoroutine(Deactivator());
    }

    private void Activate() => gameObject.SetActive(true);

    private IEnumerator Deactivator()
    {
        while (_cameraActivator.gameObject.activeSelf)
            yield return null;

        if(_cameraActivator.gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
            yield break;
        }
    }

    [Inject]
    private void Construct(LevelBuilder levelBuilder) => _levelCounter = levelBuilder.Counter;
}
