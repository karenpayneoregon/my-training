using System.Text.Json;
using DebuggingApp.Models;


namespace DebuggingApp.Classes;

public static class AppSettingsLoader
{
    public static ModelsBad.AppSettings Load()
    {
        string filePath = "appsettings.json";
        
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Config file not found: {filePath}");

        var json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<ModelsBad.AppSettings>(json, options)
               ?? throw new InvalidOperationException("Failed to deserialize appsettings.json");
    }
}