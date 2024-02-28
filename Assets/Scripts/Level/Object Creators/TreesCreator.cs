using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TreesCreator : ObjectsInstantiator
{
    [SerializeField] private List<Tree> _prefabs;

    public override void Create(uint currentLevel)
    {
        int count = (int)currentLevel;

        while (count > 0)
        {
            foreach (var tree in _prefabs)
            {
                AddInteractionObject(Instantiate(tree, levelGrid.GetRandomCellCoordinate(), Quaternion.identity, this.transform));
                count--;
            }
        }
    }

    //public override void Create()
    //{
    //    int multiplier = 2;
    //int count = LevelGenerator.CurrentLevel * multiplier;
    //int cristallCount = LevelGenerator.CurrentLevel;

    //while (count > 0)
    //{
    //    foreach (var tree in _prefabs)
    //    {
    //        Vector3 treePosition = GetRandomCoordinate();

    //        _trees.Add(Instantiate(tree, treePosition, Quaternion.identity, Container));

    //        count--;

    //        if (cristallCount > 0)
    //        {
    //            float rayHeight = 0.5f;
    //            Vector3 cristallPosition = _cristallCreator.GetRandomPosition(treePosition);

    //            while (IsEmptyGround(cristallPosition, rayHeight) == false)
    //                cristallPosition = _cristallCreator.GetRandomPosition(treePosition);

    //            _iceCristalls.Add(_cristallCreator.Create(cristallPosition));

    //            cristallCount--;
    //        }

    //        if (count == 0)
    //            break;
    //    }
    //}
    //}

    //public override void SetDefaultState()
    //{
    //    if (_trees != null)
    //    {
    //        foreach (Tree tree in _trees)
    //            tree.Destroy();

    //        foreach (Cristall cristall in _iceCristalls)
    //            cristall.Destroy();

    //        _trees.Clear();
    //        _iceCristalls.Clear();
    //    }
    //}
}