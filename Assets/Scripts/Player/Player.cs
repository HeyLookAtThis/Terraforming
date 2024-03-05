using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private List<ActiveObject> _cristalls = new List<ActiveObject>();

    private int _coinsCount;
    private int _cristallCount;
    private int _frozenVolcanoCount;
    private int _greenTreeCount;

    private UnityAction<ActiveObject, int> _countChanged;

    public event UnityAction<ActiveObject, int> ObjectCountChanged
    {
        add => _countChanged += value;
        remove => _countChanged -= value;
    }

    public int CoinsNumber => _coinsCount;

    public bool HaveCristall => _cristallCount > 0;

    public void UseObject(ActiveObject interactionObject)
    {
        int newCount = 0;

        switch(interactionObject)
        {
            case Volcano:
                newCount = ++_frozenVolcanoCount;
                break;

            case Tree:
                newCount = ++_greenTreeCount;
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

    private void AddCristall(ActiveObject interactionObject, ref int newCount)
    {
        newCount = ++_cristallCount;
        _cristalls.Add(interactionObject);
    }
}