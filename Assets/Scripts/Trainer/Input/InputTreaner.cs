using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup), typeof(RectTransform))]
public abstract class InputTreaner : MonoBehaviour
{
    public Sequence Animation;

    protected CanvasGroup Group;
    protected RectTransform Body;

    private Vector2 _positionOnScreen;
    private Vector2 _startingPosition;

    protected Vector2 PositionOnScreen => _positionOnScreen;
    protected Vector2 StartingPosition => _startingPosition;

    protected float UnitValue => 1f;
    protected float NullValue => 0f;
    protected float Duration => 0.5f;

    private bool InAnimation => Animation != null && Animation.active;

    private void Awake()
    {
        Group = GetComponent<CanvasGroup>();
        Body = GetComponent<RectTransform>();

        _positionOnScreen = Body.position;
        _startingPosition = new Vector2(_positionOnScreen.x, -Screen.height / 2);
    }

    public virtual void Show()
    {
        KillKurrentAnimationIfActive();
        Animation = DOTween.Sequence();
    }
    public virtual void Hide()
    {
        KillKurrentAnimationIfActive();
        Animation = DOTween.Sequence();
    }

    private void KillKurrentAnimationIfActive()
    {
        if (InAnimation)
            Animation.Kill();
    }
}
