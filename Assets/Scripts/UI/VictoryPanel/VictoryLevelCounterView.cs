using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class VictoryLevelCounterView : MonoBehaviour
{
    private const float Divider = 10;

    [SerializeField] private Image _image;

    private LevelCounter _levelCounter;

    private float Duration => 1f;

    private void OnEnable() => Show();

    public void Show() => _image.DOFillAmount(_levelCounter.CurrentLevel / Divider, Duration);

    [Inject]
    private void Construct(LevelBuilder levelBuilder) => _levelCounter = levelBuilder.Counter;
}
