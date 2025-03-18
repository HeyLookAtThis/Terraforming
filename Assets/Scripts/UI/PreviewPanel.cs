using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PreviewPanel : Panel, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _tMPro;

    private Sequence _animation;

    private void OnEnable() => RunFadeText();

    public void OnPointerClick(PointerEventData eventData)
    {
        StopFadeText();
        PanelSwitcher.SwitchPanel<LoadingPanel>();
    }

    private void RunFadeText()
    {
        float fadeValue = 0;
        float duration = 1;

        _animation = DOTween.Sequence();

        Tween fading = _tMPro.DOFade(fadeValue, duration);
        _animation.Append(fading).SetLoops(-1, LoopType.Yoyo);
    }

    private void StopFadeText() => _animation.Kill();
}