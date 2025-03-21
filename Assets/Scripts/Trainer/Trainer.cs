using System;
using System.Collections;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    [SerializeField] private TrainerTargetMediator _mediator;
    [SerializeField] private TrainerCameraActivator _activator;

    private Coroutine _deactivator;

    private void OnEnable() => _mediator.WasWorked += OnDeactivate;
    private void OnDisable() => _mediator.WasWorked -= OnDeactivate;

    private void OnDeactivate() 
    {
        if (_deactivator != null)
            StopCoroutine(_deactivator);

        _deactivator = StartCoroutine(Deactivator());
    }

    private IEnumerator Deactivator()
    {
        while (_activator.gameObject.activeSelf)
            yield return null;

        if(_activator.gameObject.activeSelf == false)
        {
            gameObject.SetActive(false);
            yield break;
        }
    }
}
