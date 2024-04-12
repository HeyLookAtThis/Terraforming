using UnityEngine;

public class GrassCreator : ObjectsInstantiator
{
    [SerializeField] private Grass _grass;

    public override void OnCreate()
    {
        base.OnCreate();

        if (wasCreated)
            return;

        float distance = 0.5f;

        for (float i = levelGrid.Start.x; i < levelGrid.End.x; i += distance)
        {
            for (float j = levelGrid.Start.z; j < levelGrid.End.z; j += distance)
            {
                Vector3 position = new Vector3(i, levelGrid.Start.y, j);

                if (IsEmptyGround(position))
                {
                    Grass grass = Instantiate(_grass, position, GetRandomRotation(), this.transform);
                    grass.ReturnToDefaultState();
                    AddActiveObject(grass);
                }
            }
        }

        wasCreated = true;
    }

    private Quaternion GetRandomRotation()
    {
        Quaternion quaternion = Random.rotation;

        return new Quaternion(Quaternion.identity.x, quaternion.y, Quaternion.identity.z, Quaternion.identity.w);
    }
}