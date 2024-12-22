using UnityEngine;

public class TreeFactory
{
    private TreeFactoryConfig _config;

    private LevelCounter _levelCounter;
    private GrassPainter _grassPainter;

    private TreesStorage _storage;

    public TreeFactory(TreeFactoryConfig config, LevelCounter levelCounter, GrassPainter grassPainter, TreesStorage storage)
    {
        _config = config;
        _levelCounter = levelCounter;
        _grassPainter = grassPainter;
        _storage = storage;
    }

    public void Run()
    {
        int mustCreate = _levelCounter.CurrentLevel * _config.TreesNumberPerLevelMultiplier;

        while (_storage.Count < mustCreate)
        {
            Tree tree = Object.Instantiate(_config.Prefab, _storage.Transform);
            tree.Initialize(_grassPainter);
            _storage.Add(tree);
        }
    }
}
