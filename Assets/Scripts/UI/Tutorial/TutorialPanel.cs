using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
public class TutorialPanel : MonoBehaviour, IPanel
{
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;

    private Sequence _animation;

    private float Duration => 0.15f;

    private float TransparentCanvasGroupValue => 0f;
    private float DefaultCanvasGroupValue => 1f;

    private float OffcetValue => 500f;

    private float TargetScale => 0.5f;
    private float DefaultScale => 1f;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        ResetAnimation();

        int loops = 2;

        _animation.Append(_rectTransform.DOLocalMoveX(-OffcetValue, Duration).SetLoops(loops, LoopType.Yoyo))
                    .Join(_canvasGroup.DOFade(TransparentCanvasGroupValue, Duration * loops))
                    .Join(_rectTransform.DOScale(TargetScale, Duration * loops))
                    .OnComplete(() => gameObject.SetActive(false));
    }

    public void Show()
    {
        ResetAnimation();
        gameObject.SetActive(true);

        int loops = 2;

        _animation.Append(_rectTransform.DOLocalMoveX(OffcetValue, Duration).SetLoops(loops, LoopType.Yoyo))
                    .Join(_canvasGroup.DOFade(DefaultCanvasGroupValue, Duration * loops).From(TransparentCanvasGroupValue))
                    .Join(_rectTransform.DOScale(DefaultScale, Duration * loops).From(TargetScale));
    }

    private void ResetAnimation()
    {
        _animation?.Kill();
        _animation = DOTween.Sequence();
    }
}
