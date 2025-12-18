using System.Text.Json;

namespace WorkingWithArrays1.Classes;
internal class MockedData
{

    public static decimal[] GetDecimals()
        =>
        [
            99.40m, 98.62m, 98.13m, 96.31m, 85.59m, 78.95m, 62.73m, 58.23m, 57.36m, 57.03m,
            50.41m, 49.46m, 35.86m, 30.07m, 29.84m, 27.56m, 25.73m, 17.10m, 13.95m, 10.32m
        ];

    public static void EditElement()
    {
        decimal[] decimals = GetDecimals();

        // Edit the element at index 5
        if (decimals.Length <= 5) return;
        
        Console.WriteLine(decimals[5]);
        decimals[5] = 8.00m;
        Console.WriteLine(decimals[5]);

    }

    /// <summary>
    /// Shuffles the elements of the decimal array returned by <see cref="GetDecimals"/>.
    /// </summary>
    /// <remarks>
    /// This method uses the <see cref="Random.Shared"/> instance to randomize the order of elements
    /// in the array returned by <see cref="GetDecimals"/>.
    /// </remarks>
    public static void Shuffled()
    {
        Random.Shared.Shuffle(GetDecimals());
    }

    public static void LambdaWhereLocalArray()
    {
        
        decimal[] decimals = [
            99.40m, 98.62m, 98.13m, 96.31m, 85.59m, 78.95m, 62.73m, 58.23m, 57.36m, 57.03m,
            50.41m, 49.46m, 35.86m, 30.07m, 29.84m, 27.56m, 25.73m, 17.10m, 13.95m, 10.32m
        ];

        var queried1 = decimals.Where(x => x > 50m).ToList();
        var queried2 = decimals.Where(x => x is >= 50m and <= 80m).ToList();

        List<decimal> filtered = [];

        for (var index = 0; index < decimals.Length; index++)
        {
            if (decimals[index] >= 50m && decimals[index] <= 80)
            {
                filtered.Add(decimals[index]);
            }
        }

        var areEqual = queried2.SequenceEqual(filtered);

    }
    
    public static void WriteDecimalsToJson(string filePath, decimal[] values)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string json = JsonSerializer.Serialize(values, options);
        File.WriteAllText(filePath, json);
    }

    public static decimal[] ReadDecimalsFromJson(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("JSON file not found.", filePath);

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<decimal[]>(json)
               ?? throw new InvalidDataException("Failed to deserialize decimal array.");
    }

    public static JsonSerializerOptions JsonSerializerOptions
        => new() { WriteIndented = true };
}



