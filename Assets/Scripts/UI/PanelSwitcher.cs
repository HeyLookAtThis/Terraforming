using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    private GamePanel _gamePanel;
    private EndGamePanel _endGamePanel;

    private void Awake()
    {
        _endGamePanel = GetComponentInChildren<EndGamePanel>();
        _gamePanel = GetComponentInChildren<GamePanel>();
    }

    private void Start()
    {
        _gamePanel.gameObject.SetActive(true);
        _endGamePanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _ground.Overheated += OnFunishGame;
        _endGamePanel.RestartAction += OnStartLevel;
    }

    private void OnDisable()
    {
        _ground.Overheated -= OnFunishGame;
        _endGamePanel.RestartAction -= OnStartLevel;
    }

    private void OnFunishGame()
    {
        _gamePanel.gameObject.SetActive(false);
        _endGamePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnStartLevel()
    {
        _gamePanel.gameObject.SetActive(true);
        _endGamePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
