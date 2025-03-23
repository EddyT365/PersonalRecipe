using System;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using DbUp.Support;
public static class Upgrader
{
    public static int PerformUpgrade(string connectionString)
    {
        EnsureDatabase.For.SqlDatabase(connectionString);
        
        var upgrader = DeployChanges.To.SqlDatabase(connectionString)
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(""), new SqlScriptOptions { ScriptType = ScriptType.RunOnce })
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), script => script.StartsWith(""), new SqlScriptOptions { ScriptType = ScriptType.RunAlways })
                        .LogToConsole()
                        .Build();

        var result = upgrader.PerformUpgrade();  

        if (!result.Successful)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(result.Error);
            Console.ResetColor();
            
        #if DEBUG
            Console.ReadLine();
        #endif
            return -1;  
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;   
        }
    }
 }