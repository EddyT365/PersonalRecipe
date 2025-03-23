using System;
using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

public class Program
{
    static int Main(string[] args)
    {
        // Build the configuration from appsettings.json
        // TODO: Looking into using an AppContext to get the path of the executing assembly
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        // Retrieve the connection string named "DefaultConnection"
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine("No connection string found.");
            return -1;
        }

        // Run the upgrade using the connection string
        int result = Upgrader.PerformUpgrade(connectionString); 

        // Check if the upgrade was successful
        if (result != 0)
        {
            Console.WriteLine("Database upgrade failed.");
        }
        else
        {
            Console.WriteLine("Database upgrade succeeded.");
        }

        return result;
    }
}