using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerObjectsCounter : MonoBehaviour
{
    private List<LevelObject> _cristalls = new List<LevelObject>();

    private int _coinsCount;
    private int _cristallCount;
    private int _frozenVolcanoCount;

    private uint _levelNumber;

    private UnityAction<LevelObject, int> _countChanged;
    private UnityAction _allVolcanoesFreezed;

    public event UnityAction<LevelObject, int> ValueChanged
    {
        add => _countChanged += value;
        remove => _countChanged -= value;
    }

    public event UnityAction AllVolcanoesFreezed
    {
        add => _allVolcanoesFreezed += value;
        remove => _allVolcanoesFreezed -= value;
    }

    public int CoinsNumber => _coinsCount;

    public bool HaveCristall => _cristallCount > 0;

    public void UseObject(LevelObject interactionObject)
    {
        int newCount = 0;

        switch(interactionObject)
        {
            case Volcano:
                AddVolcanoesCount(ref newCount);
                break;

            case Cristall:
                AddCristall(interactionObject, ref newCount);
                break;

            case Coin:
                newCount = ++_coinsCount;
                break;
        }

        _countChanged?.Invoke(interactionObject, newCount);
    }

    public void RemoveCristall()
    {
        _cristallCount--;
        _countChanged?.Invoke(_cristalls[0], _cristallCount);
        _cristalls.RemoveAt(0);
    }

    public void SetLevelNumber(uint number)
    {
        _levelNumber = number;
    }

    private void AddCristall(LevelObject interactionObject, ref int newCount)
    {
        newCount = ++_cristallCount;
        _cristalls.Add(interactionObject);
    }

    private void AddVolcanoesCount(ref int count)
    {
        count = ++_frozenVolcanoCount;

        if (_levelNumber == _frozenVolcanoCount)
            _allVolcanoesFreezed?.Invoke();
    }
}