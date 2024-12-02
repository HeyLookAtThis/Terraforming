using UnityEngine;

public class Tree : InteractiveObject
{
    [SerializeField] private float _radius;
    [SerializeField] private TreeView _view;

    public override void ReactToScanner()
    {
        base.ReactToScanner();
        MakeGreen();
    }

    public override void ReturnToDefaultState()
    {
        base.ReturnToDefaultState();
        Destroy(gameObject);
    }

    private void MakeGreen()
    {
        if (UsedByPlayer == false)
        {
            TurnOnUsed();
            _view.MakeGreen();
            UseObjectsAround();
        }
    }

    private void UseObjectsAround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
            if (collider.TryGetComponent<InteractiveObject>(out InteractiveObject interationObject))
                interationObject.ReactToScanner();
    }
}