using UnityEngine;
using Zenject;

public class VolcanoFreezerMediator : MonoBehaviour
{
    private CharacterLootCounter _lootCounter;
    private Scanner _scanner;

    private void OnEnable() => _scanner.FoundVolcano += OnTryFreezVolcano;

    private void OnDisable() => _scanner.FoundVolcano -= OnTryFreezVolcano;

    private void OnTryFreezVolcano(Volcano volcano)
    {
        if(volcano.IsFrozen == false && _lootCounter.SnowflakesValue > 0)
        {
            volcano.ReactToScanner();
            _lootCounter.RemoveSnowflake();
        }
    }

    [Inject]
    private void Construct(Cloud cloud, Character character)
    {
        _lootCounter = character.LootCounter;
        _scanner = cloud.Scanner;
    }
}
