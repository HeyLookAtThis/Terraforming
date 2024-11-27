using UnityEngine;

public abstract class CloudWaterIndicator
{
    protected Cloud Cloud;

    private GrassPainter _grassPainter;
    private Scanner _scanner;

    private bool _isWorking;

    public CloudWaterIndicator(Cloud cloud)
    {
        Cloud = cloud;
        _grassPainter = cloud.GrassPainter;
        _scanner = cloud.Scanner;
    }

    protected bool IsWorking => _isWorking;

    public void AddActionCallback()
    {
        _scanner.FoundWater += OnIncreaseValue;
        _scanner.LostWater += OnDecreaseValue;

        _grassPainter.Drawing += SetWorking;
    }

    public void RemoveActionCallback()
    {
        _scanner.FoundWater -= OnIncreaseValue;
        _scanner.LostWater -= OnDecreaseValue;

        _grassPainter.Drawing -= SetWorking;
    }

    protected virtual void OnIncreaseValue() { }

    protected virtual void OnDecreaseValue() { }

    private void SetWorking(bool isWorking) => _isWorking = isWorking;
}
