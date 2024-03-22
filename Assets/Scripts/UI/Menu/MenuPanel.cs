using UnityEngine;

public class MenuPanel : Panel
{
    [SerializeField] private StartButton _start;
    [SerializeField] private RatingButton _rating;
    [SerializeField] private SettingButton _setting;

    public StartButton Start => _start;
}
