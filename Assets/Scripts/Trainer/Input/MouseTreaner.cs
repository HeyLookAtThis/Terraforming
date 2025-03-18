using DG.Tweening;
using UnityEngine;

public class MouseTreaner : InputTreaner
{
    private Vector2 RightPosition => PositionOnScreen + Vector2.right * 600;

    private void OnEnable() => Show();

    public override void Show()
    {
        base.Show();

        Tween show = Group.DOFade(UnitValue, Duration).From(NullValue);
        Tween moveRight = Body.DOAnchorPos(RightPosition, 1).From(PositionOnScreen);
        Tween hide = Group.DOFade(NullValue, Duration);

        Animation.Append(show).Append(moveRight).Append(hide);
        Animation.SetLoops(-1, LoopType.Restart);
    }

    public override void Hide()
    {
        base.Hide();

        Tween hide = Group.DOFade(NullValue, Duration);
        Tween scale = Body.DOScale(NullValue, Duration).From(UnitValue);

        Animation.Append(hide).Join(scale);
    }
}
