using System.Collections.Generic;
using UnityEngine;

public class MainPlacemaker
{
    private MainStorage _storage;

    private CoinsPlacemaker _coinsPlacemaker;
    private SnowflakePlacemaker _snowflakePlacemaker;

    private CircleCoordinateSystem _cellsSystem;
    private LevelBordersMarker _levelBordersMarker;

    private List<int> _volkanoesAndTreesIndexes;

    public MainPlacemaker(MainStorage mainStorage, LevelBordersMarker marker, LevelCounter levelCounter)
    {
        _storage = mainStorage;
        _cellsSystem = new CircleCoordinateSystem(marker);
        _levelBordersMarker = marker;

        _coinsPlacemaker = new CoinsPlacemaker(marker, mainStorage.Coins);
        _snowflakePlacemaker = new SnowflakePlacemaker(mainStorage.Snowflakes, mainStorage.Trees);

        InitializeVolcanoesAddTreesIndexes();
    }

    public void Run()
    {
        Reset();

        _coinsPlacemaker.Run();
        PlaceObjecstInRandomOrder();
        _snowflakePlacemaker.Run();
    }

    private void Reset()
    {
        InitializeVolcanoesAddTreesIndexes();
        _cellsSystem.Clear();
    }

    private void InitializeVolcanoesAddTreesIndexes()
    {
        int totalCount = _storage.Volcanoes.Count + _storage.Trees.Count;
        _volkanoesAndTreesIndexes = new List<int>();

        for (int i = 0; i < totalCount; i++)
        {
            if (i < _storage.Volcanoes.Count)
                _volkanoesAndTreesIndexes.Add(i);
            else
                _volkanoesAndTreesIndexes.Add(i - _storage.Volcanoes.Count);
        }
    }

    private void PlaceObjecstInRandomOrder()
    {
        while (_volkanoesAndTreesIndexes.Count > 0)
        {
            int randomIndex = (int)Random.Range(0, _volkanoesAndTreesIndexes.Count - 1);
            int indexValue = _volkanoesAndTreesIndexes[randomIndex];
            _volkanoesAndTreesIndexes.RemoveAt(randomIndex);

            bool isVolcano = indexValue < _storage.Volcanoes.Count && _volkanoesAndTreesIndexes.Contains(indexValue) == false;

            switch (isVolcano)
            {
                case true:
                    PlaceVolcano(indexValue);
                    break;

                case false:
                    PlaceTree(indexValue);
                    break;
            }
        }
    }

    private void PlaceVolcano(int index)
    {
        IInteractiveObject volcano = _storage.Volcanoes.GetObjectTransform(index);
        _cellsSystem.PlaceObject(volcano);
        volcano.Transform.LookAt(_levelBordersMarker.Center);
    }

    public void PlaceTree(int index)
    {
        IInteractiveObject tree = _storage.Trees.GetObjectTransform(index);
        _cellsSystem.PlaceObject(tree);
    }
}
