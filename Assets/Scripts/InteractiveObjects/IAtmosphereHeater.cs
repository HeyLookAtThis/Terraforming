using UnityEngine.Events;

public interface IAtmosphereHeater
{
    event UnityAction<float> Heating;
}
