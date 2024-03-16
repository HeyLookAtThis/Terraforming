using UnityEngine;

public class FixedJoystick : Joystick
{
    public void OnFotmatInput()
    {
        this.ReturnToDefault();
    }
}