public class Snowflake : Loot
{
    public override void ReturnToDefaultState() => Destroy(gameObject);
}