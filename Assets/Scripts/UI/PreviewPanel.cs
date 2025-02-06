using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PreviewPanel : MonoBehaviour, IPanel, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _tMPro;

    private IPanelSwitcher _panelSwitcher;
    private Sequence _animation;

    private void OnEnable() => RunFadeText();

    public void OnPointerClick(PointerEventData eventData)
    {
        StopFadeText();
        _panelSwitcher.SwitchPanel<LoadingPanel>();
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    [Inject]
    private void Construct(IPanelSwitcher panelSwitcher) => _panelSwitcher = panelSwitcher;

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