using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VolcanoesDisplayer : ObjectCountDisplayer
{
    [SerializeField] private LevelCounter _levelCounter;

    private UnityAction _fulled;

    public event UnityAction Fulled
    {
        add => _fulled += value;
        remove => _fulled -= value;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        _levelCounter.NumberChanged += ShowValue;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _levelCounter.NumberChanged -= ShowValue;
    }

    protected override void ShowValue()
    {
        textMeshPro.text = $"{currentValue} / {_levelCounter.CurrentLevel}";

        if (currentValue == _levelCounter.CurrentLevel && _levelCounter.CurrentLevel > 0)
            StartCoroutine(TimeStopper());
    }

    private IEnumerator TimeStopper()
    {
        float time = 0.5f;
        float seconds = 0.1f;
        var waitTime = new WaitForEndOfFrame();

        float secondsCounter = 0f;

        while (time > secondsCounter)
        {
            if (Time.timeScale > seconds)
                Time.timeScale -= Time.deltaTime;

            secondsCounter += Time.deltaTime;
            yield return waitTime;
        }

        if(secondsCounter >= time)
        {
            _fulled?.Invoke();
            yield break;
        }
    }
}
