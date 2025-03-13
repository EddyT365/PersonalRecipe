public class Configuration
{
    private static string ConnectionString;

    public Configuration(string connectionString)
    {
        connectionString = GetConnectionString();
        ConnectionString = connectionString;
    }

    public static string GetConnectionString()
    {
        // add logic to get connection string  
        return ConnectionString;
    }
}