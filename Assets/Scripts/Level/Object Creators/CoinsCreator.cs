using UnityEngine;

public class CoinsCreator : ObjectsInstantiator
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _amount;

    public override void OnCreate()
    {
        base.OnCreate();
        int amount = _amount;

        while (amount > 0)
        {
            Vector3 position = levelGrid.GetRandomCoordinate();

            if (IsEmptyGround(position))
            {
                AddActiveObject(Instantiate(_coin, position, Quaternion.identity, this.transform));
                amount--;
            }
        }

        wasCreated = true;
    }
}