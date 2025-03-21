using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class TrainerTargetMediator : MonoBehaviour
{
    [SerializeField] private ControlTreaner _controlTreaner;
    [SerializeField] private TrainerCameraActivator _cameraActivator;
    [SerializeField] private Arrow _arrow;

    private CharacterLootCounter _lootCounter;
    private TreesStorage _treeStorage;
    private SnowflakesStorage _snowflakesStorage;
    private VolcanoesStorage _volcanoesStorage;

    private UnityAction _wasWorked;

    public event UnityAction WasWorked
    {
        add => _wasWorked += value;
        remove => _wasWorked -= value;
    }

    private int FirstIndex => 0;

    private void OnEnable()
    {
        _controlTreaner.Completed += OnShowTree;
        _lootCounter.SnowflakeAdded += OnShowVolcano;
        _snowflakesStorage.GetSnowflake(FirstIndex).View.TurnedOn += OnShowSnowflake;
    }

    private void OnDisable()
    {
        _controlTreaner.Completed -= OnShowTree;
        _lootCounter.SnowflakeAdded -= OnShowVolcano;
        _snowflakesStorage.GetSnowflake(FirstIndex).View.TurnedOn -= OnShowSnowflake;
    }

    private void OnShowTree()
    {
        Transform tree = _treeStorage.GetObjectTransform(FirstIndex).Transform;

        _arrow.SetTarget(tree);
        _arrow.Activate();

        _cameraActivator.SetTarget(_treeStorage.GetObjectTransform(FirstIndex).Transform);
    }

    private void OnShowSnowflake()
    {
        Transform snowflake = _snowflakesStorage.GetObjectTransform(FirstIndex).Transform;

        _arrow.SetTarget(snowflake);
        _cameraActivator.SetTarget(_snowflakesStorage.GetObjectTransform(FirstIndex).Transform);
    }

    private void OnShowVolcano(int snowflakes)
    {
        if (_volcanoesStorage.Count != 0)
        {
            Transform volcano = _volcanoesStorage.GetObjectTransform(FirstIndex).Transform;

            _arrow.InitializeVolcano(_volcanoesStorage.GetVolcano(FirstIndex));
            _arrow.SetTarget(volcano);

            _cameraActivator.SetTarget(volcano);

            gameObject.SetActive(false);
            _wasWorked?.Invoke();
        }
    }

    [Inject]
    private void Construct(Character character, LevelBuilder levelBuilder)
    {
        _lootCounter = character.LootCounter;
        _snowflakesStorage = levelBuilder.MainStorage.Snowflakes;
        _volcanoesStorage = levelBuilder.MainStorage.Volcanoes;
        _treeStorage = levelBuilder.MainStorage.Trees;
    }
}
