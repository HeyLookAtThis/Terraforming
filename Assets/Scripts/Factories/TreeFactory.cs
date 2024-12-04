using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFactory
{
    private TreeFactoryConfig _config;
    private List<Tree> _trees;

    private LevelCounter _levelCounter;
    private GrassPainter _grassPainter;

    public TreeFactory(TreeFactoryConfig config, LevelCounter levelCounter, GrassPainter grassPainter)
    {
        _config = config;
        _trees = new List<Tree>();
        _levelCounter = levelCounter;
        _grassPainter = grassPainter;
    }

    public int Count => _trees.Count;

    public void Run()
    {
        int createdCount = 0;
        int mustCreate = _levelCounter.CurrentLevel * _config.TreesNumberPerLevelMultiplier;
        GameObject storage = new GameObject("TreeStorage");

        while (createdCount < mustCreate)
        {
            Tree tree = Object.Instantiate(_config.Prefab, storage.transform);
            tree.Initialize(_grassPainter);
            _trees.Add(tree);
            createdCount++;
        }
    }

    public IInteractiveObject GetTree(int index) => _trees[index];
}
