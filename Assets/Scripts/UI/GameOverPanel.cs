using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverPanel : Panel
{
    [SerializeField] private RestartButton _restartButton;

    public RestartButton RestartButton => _restartButton;
}
