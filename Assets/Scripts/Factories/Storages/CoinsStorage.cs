public class CoinsStorage : ObjectsStorage
{
    public CoinsStorage(string storageName) : base(storageName)
    {
    }

    public Coin GetCoin(int index) => (Coin)InteractiveObjects[index];
}
