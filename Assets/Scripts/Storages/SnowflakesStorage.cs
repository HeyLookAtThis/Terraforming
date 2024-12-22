public class SnowflakesStorage : ObjectsStorage
{
    public SnowflakesStorage(string storageName) : base(storageName)
    {
    }

    public Snowflake GetSnowflake(int index) => (Snowflake)InteractiveObjects[index];
}
