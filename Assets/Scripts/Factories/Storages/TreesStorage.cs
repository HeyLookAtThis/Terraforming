public class TreesStorage : ObjectsStorage
{
    public TreesStorage(string storageName) : base(storageName)
    {
    }

    public Tree GetTree(int index) => (Tree)InteractiveObjects[index];
}
