using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerObjectsCounter : MonoBehaviour
{
    private List<LevelObject> _cristalls = new List<LevelObject>();

    private int _coinsCount;
    private int _cristallCount;
    private int _frozenVolcanoCount;

    private UnityAction<LevelObject, int> _countChanged;

    public event UnityAction<LevelObject, int> ValueChanged
    {
        add => _countChanged += value;
        remove => _countChanged -= value;
    }

    public int CoinsNumber => _coinsCount;

    public bool HaveCristall => _cristallCount > 0;

    public void UseObject(LevelObject interactionObject)
    {
        int newCount = 0;

        switch(interactionObject)
        {
            case Volcano:
                newCount = ++_frozenVolcanoCount;
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

    private void AddCristall(LevelObject interactionObject, ref int newCount)
    {
        newCount = ++_cristallCount;
        _cristalls.Add(interactionObject);
    }
}