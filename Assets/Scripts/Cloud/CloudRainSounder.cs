public class CloudRainSounder : CloudSounder
{
    private void OnEnable()
    {
        scanner.FoundInteractionObject += Run;
    }

    private void OnDisable()
    {
        scanner.FoundInteractionObject -= Run;
    }
}
