using UnityEngine;
using Zenject;

public class WinMediator : MonoBehaviour
{
    [SerializeField] private PanelsSwither _panelsSwither;
    [SerializeField] private LevelBuilder _levelBuilder;

    private VolcanoStorage _volcanoStorage;

    private void Awake()
    {
        _volcanoStorage = _levelBuilder.MainFactory.Volcanoes.Storage;
    }

    private void OnEnable()
    {
        _volcanoStorage.AllVolcanoesFrozen += _panelsSwither.OnTurnOnWinPanel;
    }

    private void OnDisable()
    {
        _volcanoStorage.AllVolcanoesFrozen -= _panelsSwither.OnTurnOnWinPanel;
    }
}
