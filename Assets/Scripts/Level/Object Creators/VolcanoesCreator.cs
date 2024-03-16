using UnityEngine;

public class VolcanoesCreator : ObjectsInstantiator
{
    [SerializeField] private Volcano _prefab;
    [SerializeField] private Ground _ground;

    public override void OnCreate()
    {
        base.OnCreate();
        int count = (int)currentLevel;
        _ground.InitializeTemperature(_prefab.Temperature, currentLevel);

        while (count > 0)
        {
            Volcano volcano = Instantiate(_prefab, GetAllowedCoordinate(), Quaternion.identity, this.transform);
            volcano.BeginHeatGround(_ground);
            AddActiveObject(volcano);
            count--;
        }

        wasCreated = true;
    }
}