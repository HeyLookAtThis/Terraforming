using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _coinsCount;
    private int _cristallCount;
    private int _frozenVolcanoCount;
    private int _greenTreeCount;

    private UnityAction<InteractionObject, int> _countChanged;

    public event UnityAction<InteractionObject, int> CountChanged
    {
        add => _countChanged += value;
        remove => _countChanged -= value;
    }

    public int CoinsNumber => _coinsCount;

    public bool HaveCristall => _cristallCount > 0;

    public void UseObject(InteractionObject interactionObject)
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

            //case Cristall:
            //    newCount = ++_cristallCount;
            //    break;

            //case Coin:
            //    newCount = ++_coinsCount;
            //    break;
        }

        _countChanged?.Invoke(interactionObject, newCount);
    }
}