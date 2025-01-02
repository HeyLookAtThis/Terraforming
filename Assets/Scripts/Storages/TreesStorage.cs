using UnityEngine;

public class TreesStorage : ObjectsStorage
{
    public TreesStorage(string storageName) : base(storageName)
    {
    }

    public Vector3 GetPosition(int index) => GetObjectTransform(index).Transform.position;
}
