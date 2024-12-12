public class SnowflakeStorage : ObjectsStorage
{
    public SnowflakeStorage(string storageName) : base(storageName)
    {
    }

    public Snowflake GetSnowflake(int index) => (Snowflake)InteractiveObjects[index];
}
