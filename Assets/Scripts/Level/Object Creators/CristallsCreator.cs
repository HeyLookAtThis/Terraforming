using System.Collections.Generic;
using UnityEngine;

public class CristallCreator : ObjectsInstantiator
{
    [SerializeField] private Cristall _cristall;
    [SerializeField] private TreesCreator _treesCreator;

    protected override void OnEnable()
    {
        base.OnEnable();
        _treesCreator.OnFinished += OnSetPositions;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _treesCreator.OnFinished -= OnSetPositions;
    }

    public override void OnCreate()
    {
        base.OnCreate();
        int count = (int)currentLevel;

        while (count > 0)
        {
            Cristall cristall = Instantiate(_cristall, transform.position, Quaternion.identity, this.transform);
            AddActiveObject(cristall);
            count--;
        }

        wasCreated = true;
    }

    private void OnSetPositions(IReadOnlyList<Vector3> treePositions)
    {
        for(int i = 0; i < activeObjects.Count; i++)
            activeObjects[i].transform.position = GetPositionNearTree(treePositions[i]);
    }

    private Vector3 GetPositionNearTree(Vector3 treePosition)
    {
        float minDistance = 0.5f;
        float maxDistance = 1f;

        Vector3 randomPosition = treePosition;

        randomPosition.x += Random.Range(minDistance, maxDistance) * GetRandomMultiplier();
        randomPosition.z += Random.Range(minDistance, maxDistance) * GetRandomMultiplier();

        return randomPosition;
    }

    private int GetRandomMultiplier()
    {
        int positiveMultiplier = 1;
        int negativeMultiplier = -positiveMultiplier;

        float randomValue = Random.Range(positiveMultiplier, negativeMultiplier);

        if (randomValue <= 0)
            return negativeMultiplier;

        return positiveMultiplier;
    }
}