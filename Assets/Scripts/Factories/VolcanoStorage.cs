public class VolcanoStorage : ObjectsStorage
{
    public VolcanoStorage(string storageName) : base(storageName)
    {
    }

    public Volcano GetVolcano(int index) => (Volcano)InteractiveObjects[index];
}
