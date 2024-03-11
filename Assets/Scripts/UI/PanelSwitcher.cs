using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    private GamePanel _game;
    private EndGamePanel _endGame;
    private TitlePanel _title;

    private void Awake()
    {
        _endGame = GetComponentInChildren<EndGamePanel>();
        _game = GetComponentInChildren<GamePanel>();
        _title = GetComponentInChildren<TitlePanel>();
    }

    private void Start()
    {
        StartGame();
    }

    private void OnEnable()
    {
        _ground.Overheated += OnFinishGame;
        _endGame.RestartAction += OnStartLevel;
        _title.Clicked += OnStartLevel;
    }

    private void OnDisable()
    {
        _ground.Overheated -= OnFinishGame;
        _endGame.RestartAction -= OnStartLevel;
        _title.Clicked -= OnStartLevel;
    }

    private void StartGame()
    {
        _title.gameObject.SetActive(true);
        _game.gameObject.SetActive(false);
        _endGame.gameObject.SetActive(false);
    }

    private void OnFinishGame()
    {
        _game.gameObject.SetActive(false);
        _endGame.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnStartLevel()
    {
        _game.gameObject.SetActive(true);
        _endGame.gameObject.SetActive(false);
        _title.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
