using UnityEngine;

public class WinPanel : Panel
{
    [SerializeField] private RestartButton _restartButton;
    [SerializeField] private StartButton _continueButton;

    public RestartButton RestartButton => _restartButton;

    public StartButton ContinueButton => _continueButton;
}
