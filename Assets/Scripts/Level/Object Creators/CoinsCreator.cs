using UnityEngine;

public class CoinsCreator : ObjectsInstantiator
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _amount;

    public override void OnCreate(uint currentLevel)
    {
        base.OnCreate(currentLevel);
        int amount = _amount;

        while (amount > 0)
        {
            Vector3 position = levelGrid.GetRandomCoordinate();

            if (IsEmptyGround(position))
            {
                AddInteractionObject(Instantiate(_coin, position, Quaternion.identity, this.transform));
                amount--;
            }
        }

        wasCreated = true;
    }
}