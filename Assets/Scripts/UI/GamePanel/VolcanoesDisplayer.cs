using UnityEngine;

public class VolcanoesDisplayer : ObjectCountDisplayer
{
    [SerializeField] private LevelCounter _levelCounter;

    protected override void ShowValue()
    {
        textMeshPro.text = $"{currentValue} / {_levelCounter.CurrentLevel}";
    }
}
