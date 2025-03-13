using System.Reflection;
using DbUp;
public class Program
{
    static void Main(string[] args)
        {
            Upgrader.PerformUpgrade(Configuration.GetConnectionString());
        }
}
