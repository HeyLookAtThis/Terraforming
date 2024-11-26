public abstract class CloudWaterIndicator
{
    protected Cloud Cloud;

    private Scanner _scanner;

    public CloudWaterIndicator(Cloud cloud)
    {
        Cloud = cloud;
        _scanner = cloud.Scanner;
    }

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
}
