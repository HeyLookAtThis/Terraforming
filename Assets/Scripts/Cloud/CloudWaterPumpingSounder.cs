public class CloudWaterPumpingSounder : CloudSounder
{
    private void OnEnable()
    {
        scanner.FoundWater += Run;
    }

    private void OnDisable()
    {
        scanner.FoundWater -= Run;
    }
}
