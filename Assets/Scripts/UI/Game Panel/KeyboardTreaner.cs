using DG.Tweening;
using UnityEngine;

public class KeyboardTreaner : InputTreaner
{
    public override void Show()
    {
        base.Show();

        float blinkingDuration = Duration * 2;
        float blinkingAlphaValue = 0.7f;

        Tween show = Group.DOFade(UnitValue, Duration).From(NullValue);
        Tween scale = Body.DOScale(UnitValue, Duration).From(NullValue);
        Tween move = Body.DOAnchorPos(PositionOnScreen, Duration).From(StartingPosition);
        Tween blinking = Group.DOFade(blinkingAlphaValue, blinkingDuration).From(UnitValue).SetLoops(-1, LoopType.Yoyo);

        Animation.Append(show).Join(scale).Join(move).Append(blinking);
    }

    public override void Hide()
    {
        base.Hide();

        Tween show = Group.DOFade(NullValue, Duration);
        Tween scale = Body.DOScale(NullValue, Duration).From(UnitValue);
        Tween move = Body.DOAnchorPos(StartingPosition, Duration);

        Animation.Append(show).Join(scale).Join(move);
    }
}
