using DG.Tweening;

public class KeyboardTreaner : InputTreaner
{
    public override void Show()
    {
        base.Show();

        float blinkingDuration = Duration * 2;
        float blinkingAlphaValue = 0.7f;
        int loops = 10;

        Animation.Append(Group.DOFade(UnitValue, Duration).From(NullValue))
            .Join(Body.DOScale(UnitValue, Duration).From(NullValue))
            .Join(Body.DOAnchorPos(PositionOnScreen, Duration).From(StartingPosition))
            .Append(Group.DOFade(blinkingAlphaValue, blinkingDuration).From(UnitValue).SetLoops(loops, LoopType.Yoyo));
    }

    public override void Hide()
    {
        base.Hide();

        Animation.Append(Group.DOFade(NullValue, Duration))
            .Join(Body.DOScale(NullValue, Duration).From(UnitValue))
            .Join(Body.DOAnchorPos(StartingPosition, Duration));
    }
}
