using UnityEngine;

public class VolcanoesCreator : ObjectsInstantiator
{
    [SerializeField] private Volcano _prefab;
    [SerializeField] private Ground _ground;

    public override void OnCreate(uint currentLevel)
    {
        base.OnCreate(currentLevel);
        int count = (int)currentLevel;
        _ground.InitializeTemperature(_prefab.Temperature, currentLevel);

        while (count > 0)
        {
            Volcano volcano = Instantiate(_prefab, GetAllowedCoordinate(), Quaternion.identity, this.transform);
            volcano.BeginHeatGround(_ground);
            AddInteractionObject(volcano);
            count--;
        }

        wasCreated = true;
    }
}