using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : AirborneState
{
    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}
