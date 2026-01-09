using System.Drawing;

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

    public static void GetLevel1(int value)
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
            case > 3:
                Console.WriteLine("High");
                break;
            default:
                throw new ArgumentException($"Invalid value: {value}");
        }
    }

    // Simplified syntax using 'or' pattern
    public static void GetLevel1A(int value)
    {
        switch (value)
        {
            case 1 or 2 or 3:  // Using 'or' pattern which optimizes multiple cases
                {
                    Console.WriteLine("Low");
                    break;
                }

            default:
                Console.WriteLine("High");
                break;
        }
    }

    public static void GetLevel2(int value)
    {
        switch (value)
        {
            case >= 1 and <= 3:
                Console.WriteLine("Low");
                break;
            default:
                Console.WriteLine("High");
                break;
        }
    }


    /// <summary>
    /// Demonstrates type checking using a <see langword="switch"/> statement.
    /// </summary>
    /// <param name="sender">
    /// The object to be checked. The method identifies the type of the object and performs
    /// specific actions based on its type.
    /// </param>
    /// <remarks>
    /// This method handles the following types:
    /// <list type="bullet">
    /// <item><description><see cref="int"/>: Prints the integer value.</description></item>
    /// <item><description><see cref="string"/>: Prints the string value.</description></item>
    /// <item><description>Other types: Prints "Unknown type".</description></item>
    /// </list>
    /// </remarks>
    public static void TypeCheckingSample1(object sender)
    {
        switch (sender)
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
            case int integer and > 0:
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

    public static Color GetSeasonColor(int month)
    {
        switch (month)
        {
            case 1 or 2 or 12:
                return Color.Red;
            case > 2 and < 6:
                return Color.CadetBlue;
            case > 5 and < 9:
                return Color.Yellow;
            case > 8 and < 12:
                return Color.Cyan;
            default:
                return Color.White;
        }
    }


    public static Color GetSeasonColorMerged(int month)
        => month switch
        {
            1 or 2 or 12 => Color.Red,
            > 2 and < 6 => Color.CadetBlue,
            > 5 and < 9 => Color.Yellow,
            > 8 and < 12 => Color.Cyan,
            _ => Color.White
        };


    public static void EnumSample(Direction currentDirection = Direction.North)
    {

        switch (currentDirection)
        {
            case Direction.North:
                Console.WriteLine("Facing North");
                break;
            case Direction.South:
                Console.WriteLine("Facing South");
                break;
            case Direction.East:
                Console.WriteLine("Facing East");
                break;
            case Direction.West:
                Console.WriteLine("Facing West");
                break;
            default:
                Console.WriteLine("Unknown direction");
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

    public void HandlePersonOperation(PersonOperation operation, Person person)
    {
        switch (operation)
        {
            case PersonOperation.Display:
                DisplayPerson(person);
                break;

            case PersonOperation.Create:
                CreatePerson(person);
                break;

            case PersonOperation.Read:
                ReadPerson(person);
                break;

            case PersonOperation.Update:
                UpdatePerson(person);
                break;

            case PersonOperation.Delete:
                DeletePerson(person);
                break;

            default:
                throw new ArgumentOutOfRangeException(
                    nameof(operation),
                    operation,
                    "Unsupported person operation");
        }
    }

    #region Simulation for data operations

    public void DisplayPerson(Person person)
    {
        Console.WriteLine($"{person.Name}, Age {person.Age}");
    }

    public void CreatePerson(Person person)
    {
        Console.WriteLine("Create new person");
    }

    public void ReadPerson(Person person)
    {
        Console.WriteLine($"Read person: {person.Name}, Age {person.Age}");
    }

    public void UpdatePerson(Person person)
    {
        Console.WriteLine($"Update person: {person.Name}, Age {person.Age}");
    }

    public void DeletePerson(Person person)
    {
        Console.WriteLine($"Delete person: {person.Name}, Age {person.Age}");
    }

    #endregion


}

public class Person(string name, int age)
{
    public string Name { get; init; } = name;
    public int Age { get; init; } = age;

    public void Deconstruct(out string name, out int age)
    {
        name = this.Name;
        age = this.Age;
    }
}

public enum Direction
{
    North,
    South,
    East,
    West
}

public enum PersonOperation
{
    Display,
    Create,
    Read,
    Update,
    Delete
}
