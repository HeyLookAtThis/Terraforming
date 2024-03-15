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

    protected override void ShowValue()
    {
        textMeshPro.text = $"{currentValue} / {_levelCounter.CurrentLevel}";

        if(currentValue == _levelCounter.CurrentLevel)
            _fulled?.Invoke();
    }
}
