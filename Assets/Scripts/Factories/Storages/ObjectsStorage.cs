using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsStorage
{
    private List<InteractiveObject> _interactiveObjects;
    private GameObject _gameObject;

    public ObjectsStorage(string storageName)
    {
        _interactiveObjects = new List<InteractiveObject>();
        _gameObject = new GameObject(storageName);
    }

    protected IReadOnlyList<InteractiveObject> InteractiveObjects => _interactiveObjects;

    public int Count => _interactiveObjects.Count;
    public Transform Transform => _gameObject.transform;

    public void Add(InteractiveObject interactiveObject) => _interactiveObjects.Add(interactiveObject);
    public void Remove(InteractiveObject interactiveObject) => _interactiveObjects.Remove(interactiveObject);
    public IInteractiveObject GetObjectTransform(int index) => _interactiveObjects[index];
}
