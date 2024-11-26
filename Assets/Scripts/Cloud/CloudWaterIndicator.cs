public abstract class CloudWaterIndicator
{
    protected Cloud Cloud;

    private Scanner _scanner;
    private bool _isWorking;

    public CloudWaterIndicator(Cloud cloud)
    {
        Cloud = cloud;
        _scanner = cloud.Scanner;
    }

    protected bool IsWorking => _isWorking;

    public void AddActionCallback()
    {
        _scanner.FoundWater += OnIncreaseValue;
        _scanner.LostWater += OnDecreaseValue;
    }

    public void RemoveActionCallback()
    {
        _scanner.FoundWater -= OnIncreaseValue;
        _scanner.LostWater -= OnDecreaseValue;
    }

    protected abstract void OnIncreaseValue();
    protected abstract void OnDecreaseValue();

    protected void StopWorking() => _isWorking = false;
    protected void StartWorking() => _isWorking = true;
}
