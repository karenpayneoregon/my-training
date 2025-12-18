using System.Text.Json;

namespace WorkingWithArrays1;

internal class Program
{
    static void Main(string[] args)
    {
   
        if (!Directory.Exists("Json"))
        {
            Directory.CreateDirectory("Json");
        }
        
        var fileName = Path.Combine("Json", "decimals.json");

        var decimals = Classes.MockedData.GetDecimals();
        
        Classes.MockedData.WriteDecimalsToJson(fileName, decimals);

        var readDecimals = Classes.MockedData.ReadDecimalsFromJson(fileName);
        var json = JsonSerializer.Serialize(readDecimals, Classes.MockedData.JsonSerializerOptions);
        
        Console.WriteLine(json);

        Console.WriteLine("Press ENTER to exit");
        Console.ReadLine();
    }
}
