using UnityEngine;

public class FixedJoystick : Joystick
{
    public void OnFotmatInput(uint currentLevel)
    {
        this.ReturnToDefault();
    }
}