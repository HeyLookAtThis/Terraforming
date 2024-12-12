using UnityEngine;

public class TreeFactory
{
    private TreeFactoryConfig _config;

    private LevelCounter _levelCounter;
    private GrassPainter _grassPainter;

    private TreesStorage _storage;

    public TreeFactory(TreeFactoryConfig config, LevelCounter levelCounter, GrassPainter grassPainter)
    {
        _config = config;
        _levelCounter = levelCounter;
        _grassPainter = grassPainter;

        string storageName = "TreesStorage";
        _storage = new TreesStorage(storageName);
    }

    public TreesStorage Storage => _storage;

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

    public void Clear()
    {
        for (int i = 0; i < _storage.Count; i++)
        {
            Tree tree = _storage.GetTree(i);
            _storage.Remove(tree);
            tree.ReturnToDefaultState();
        }
    }
}
