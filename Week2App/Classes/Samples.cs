using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Week2App.Classes;
internal class Samples
{
    public static (string, string) GetGradeWithRemarks(int score)
    {
        if (score is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(score), score, "Score must be between 0 and 100");

        switch (score)
        {
            case >= 90:
                return ("A", "Great job");
            case >= 80:
                return ("B", "Good");
            case >= 70:
                return ("C", "Okay");
            case >= 60:
                return ("D", "Better study");
            default:
                return ("F", "You failed");
        }
    }

    public static void GetLevel(int value)
    {
        switch (value)
        {
            case 1:
            case 2:
            case 3:
            {
                Console.WriteLine("Low");
                break;
            }

            default:
                Console.WriteLine("High");
                break;
        }
    }

    public static void TypeCheckingSample1(object obj)
    {
        switch (obj)
        {
            case int intValue:
                Console.WriteLine($"Integer value: {intValue}");
                break;
            case string strValue:
                Console.WriteLine($"String value: {strValue}");
                break;
            default:
                Console.WriteLine("Unknown type");
                break;
        }
    }

    public static void TypeCheckingSample2(object sender)
    {

        switch (sender)
        {
            case int integer when integer > 0:
                Console.WriteLine("Positive integer");
                break;

            case int integer when integer <= 0:
                Console.WriteLine("Zero or negative integer");
                break;

            case string str when str.Length > 10:
                Console.WriteLine("Long string");
                break;

            case string str when str.Length <= 10:
                Console.WriteLine("Short string");
                break;

            default:
                Console.WriteLine("Unknown type");
                break;
        }

    }

    // Person person = new("Alice", 17);
    public static string GetPersonCategory(Person person)
    {
        switch (person)
        {
            case { Age: < 13 }:
                return "Child";
            case { Age: >= 13 and < 20 }:
                return "Teenager";
            case { Age: >= 20 and < 65 }:
                return "Adult";
            case { Age: >= 65 }:
                return "Senior";
            default:
                return "Unknown";
        }
    }

}

public record Person(string Name, int Age);
