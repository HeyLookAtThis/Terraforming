using UnityEngine;

public class GrassCreator : ObjectsInstantiator
{
    [SerializeField] private Grass _grass;

    public override void OnCreate(uint currentLevel)
    {
        base.OnCreate(currentLevel);

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
                    Grass grass = Instantiate(_grass, position, Quaternion.identity, this.transform);
                    grass.ReturnToDefaultState();
                    AddInteractionObject(grass);
                }
            }
        }

        wasCreated = true;
    }
}