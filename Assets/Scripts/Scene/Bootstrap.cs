using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour, IInitializable
{
    [SerializeField] private PanelsSwither _panelsSwither;
    [SerializeField] private LevelBuilder _levelBuilder;

    public void Initialize()
    {
        _panelsSwither.OnTurnOnGamePanel();
        _levelBuilder.Run();
    }
}
