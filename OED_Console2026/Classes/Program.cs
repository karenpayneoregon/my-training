using ConsoleConfigurationLibrary.Classes;
using ConsoleHelperLibrary.Classes;
using Microsoft.Extensions.DependencyInjection;
using OED_Console2026.Classes.System;
using System.Reflection;
using System.Runtime.CompilerServices;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;

// ReSharper disable once CheckNamespace
namespace OED_Console2026;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        
        SpectreConsoleHelpers.SetEncoding();
        
        var assembly = Assembly.GetEntryAssembly();
        var product = assembly?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;

        Console.Title = product!;

        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

        SetupLogging.Development();
        
        Setup();

    }
    
    /// <summary>
    /// Configures and initializes the required services for the application.
    /// </summary>
    /// <remarks>
    /// This method sets up dependency injection by configuring services, building a service provider,
    /// and retrieving necessary configurations such as connection strings and entity settings.
    /// </remarks>
    private static void Setup()
    {
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();
        
        setup?.GetConnectionStrings();
        setup?.GetEntitySettings();
        
    }
}
