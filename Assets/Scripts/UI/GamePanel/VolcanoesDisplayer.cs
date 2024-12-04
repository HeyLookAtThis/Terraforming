using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class VolcanoesDisplayer : ObjectCountDisplayer
{
    [SerializeField] private OldLevelCounter _levelCounter;

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
    }
}
