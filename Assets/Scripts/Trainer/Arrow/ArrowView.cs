using DG.Tweening;
using UnityEngine;

public class ArrowView : MonoBehaviour
{
    private void OnEnable()
    {
        float targetValue = 1f;
        float duration = 0.5f;

        Sequence animation = DOTween.Sequence();
        animation.Append(transform.DOLocalMove(Vector3.forward * targetValue, duration)).
            Join(transform.DOScale(targetValue, duration)).
            SetLoops(-1, LoopType.Yoyo);
    }
}
