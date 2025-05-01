using DG.Tweening;
using UnityEngine;

public class MouseTreaner : InputTreaner
{
    private float Offset => 600f;
    private Vector2 RightPosition => PositionOnScreen + Vector2.right * Offset;

    private void OnEnable() => Show();

    public override void Show()
    {
        base.Show();

        Animation.Append(Group.DOFade(UnitValue, Duration).From(NullValue))
            .Join(Body.DOScale(UnitValue, Duration).From(NullValue))
            .Append(Body.DOAnchorPos(RightPosition, 1).From(PositionOnScreen))
            .Append(Group.DOFade(NullValue, Duration))
            .Join(Body.DOScale(NullValue, Duration).From(UnitValue));

        Animation.SetLoops(-1, LoopType.Restart);
    }

    public override void Hide()
    {
        base.Hide();

        Animation.Append(Group.DOFade(NullValue, Duration))
            .Join(Body.DOScale(NullValue, Duration).From(UnitValue));
    }
}
