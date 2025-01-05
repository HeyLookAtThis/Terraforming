using UnityEngine;

public class Cell
{
    private Vector3 _position;
    private bool _isFree;

    public Cell(Vector3 position)
    {
        _position = position;
        Clear();
    }

    public void Occupy(IInteractiveObject interactiveObject)
    {
        if (_isFree)
        {
            interactiveObject.Transform.position = _position;
            _isFree = false;
        }
    }

    public void Clear() => _isFree = true;
}
