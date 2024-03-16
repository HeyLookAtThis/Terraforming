using UnityEngine;

public class GamePanel : Panel
{
    [SerializeField] private PlayerInstantiator _playerInstantiator;
    [SerializeField] private LevelGenerator _levelGenerator;

    public PlayerInstantiator PlayerInstantiator => _playerInstantiator;

    public LevelGenerator LevelGenerator => _levelGenerator;
}
