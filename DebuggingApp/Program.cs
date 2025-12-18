using DebuggingApp.Classes;

namespace DebuggingApp;

internal class Program
{
    static void Main(string[] args)
    {
        var settings = AppSettingsLoader.Load();

        Console.WriteLine(settings.Connectionstrings.Mainconnection);
        Console.WriteLine(settings.EntityConfiguration.CreateNew);
        Console.ReadLine();
    }
}



