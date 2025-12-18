using System.Text.Json;

namespace WorkingWithArrays;

internal class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Press ENTER to exit");
        Console.ReadLine();
    }

    private static void Lesson1()
    {
        if (!Directory.Exists("Json"))
        {
            Directory.CreateDirectory("Json");
        }
        var decimals = Classes.MockedData.GetDecimals();

        var fileName = Path.Combine("Json", "decimals.json");
        List<decimal> queried1 = decimals.Where(x => x > 50m).ToList();
        
        Classes.MockedData.WriteDecimalsToJson(fileName, decimals);

        var json = JsonSerializer.Serialize(queried1, Classes.MockedData.JsonSerializerOptions);

        Console.WriteLine(json);
    }
}