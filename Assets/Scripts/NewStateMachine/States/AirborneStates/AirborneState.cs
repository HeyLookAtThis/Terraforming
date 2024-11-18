using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneState : MovementState
{
    public AirborneState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }
}
