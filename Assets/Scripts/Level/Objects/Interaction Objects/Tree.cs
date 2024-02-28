using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractionObject
{
    [SerializeField] private float _radius;
    [SerializeField] private List<GameObject> _emptyTunks;
    [SerializeField] private List<GameObject> _greenTrunks;

    public override void ReactToPlayer(Player player)
    {
        MakeGreen();
    }

    public override void ReactToTree()
    {
        MakeGreen();
    }

    public override void ReturnToDefaultState()
    {
        Destroy(gameObject);
    }

    private void MakeGreen()
    {
        if (WasUsedByPlayer == false)
        {
            TurnOnUsed();
            ChangeModels();
            UseObjectsAround();
        }
    }

    public void ChangeModels()
    {
        foreach (var tunk in _emptyTunks)
            tunk.SetActive(false);

        foreach (var tunk in _greenTrunks)
            tunk.SetActive(true);
    }

    private void UseObjectsAround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
            if (collider.TryGetComponent<InteractionObject>(out InteractionObject interationObject))
                interationObject.ReactToTree();
    }
}