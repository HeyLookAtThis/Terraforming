public interface IGameTimer
{
    float PlayingTimeScale { get; }
    float PausingTimeScale { get; }

    void StartGame();
    void StopGame();
}
