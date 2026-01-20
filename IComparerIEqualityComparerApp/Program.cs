using System.Diagnostics;
using IComparerIEqualityComparerApp.Classes;
using IComparerIEqualityComparerApp.Classes.Comparers;
using IComparerIEqualityComparerApp.Classes.SystemCode;
using IComparerIEqualityComparerApp.Models;
using Serilog;
using Spectre.Console;

namespace IComparerIEqualityComparerApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        //Log.Information("Application started by {UserName}", Environment.UserName);
        //DistinctPeople();
        //CompareProducts();
        //PersonSortedByLastNameExample();


        var p = Person();

        if (p.FirstName == "John")
        {
            p.FirstName = "Jane";
        }
        else
        {

        }


        SpectreConsoleHelpers.ExitPrompt();
    }

    public static Person Person()
    {
        return new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1990, 1, 1)
        };
    }

    /// <summary>
    /// Demonstrates the use of the <see cref="FirstNameLastNameBirthDateEqualityComparer"/> 
    /// to filter a list of <see cref="Person"/> objects and display only distinct entries 
    /// based on their first name, last name, and birthdate.
    /// </summary>
    /// <remarks>
    /// This method creates a list of <see cref="Person"/> objects, applies the 
    /// <see cref="FirstNameLastNameBirthDateEqualityComparer"/> to identify distinct entries, 
    /// and then prints the distinct people to the console.
    /// </remarks>
    private static void DistinctPeople()
    {
        var people = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1990, 1, 1) },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", BirthDate = new DateOnly(1992, 2, 2) },
            new Person { Id = 3, FirstName = "John", LastName = "Doe", BirthDate = new DateOnly(1990, 1, 1) },
        };

        var distinctPeople = people.Distinct(new FirstNameLastNameBirthDateEqualityComparer()).ToList();

        AnsiConsole.MarkupLine("[bold]Distinct People:[/]");
        foreach (var person in distinctPeople)
        {
            AnsiConsole.MarkupLine($"[DeepPink3]{person.FirstName,8} {person.LastName} {person.BirthDate}[/]");
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Creates and returns a list of <see cref="Person"/> objects, sorted by their last names.
    /// </summary>
    /// <returns>
    /// A <see cref="List{T}"/> of <see cref="Person"/> objects, ordered by the <see cref="Person.LastName"/> property.
    /// </returns>
    private static List<Person> PeopleDataList()
    {
        List<Person> peopleList =
        [
            new() { Id = 1, FirstName = "Mike", LastName = "Williams", BirthDate = new DateOnly(1956,9,24)},
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956, 9, 24) },
            new() { Id = 2, FirstName = "Sam", LastName = "Smith", BirthDate = new DateOnly(1976, 3, 4) },
            new() { Id = 1, FirstName = "Karen", LastName = "Payne", BirthDate = new DateOnly(1956, 9, 24) }
        ];

        return peopleList.OrderBy(x => x.LastName).ToList();
    }

    private static void PersonSortedByLastNameExample()
    {

        var list = PeopleDataList();

        SortedSet<Person> people = new(new PersonComparer());

        people.AddRange(list);

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }

        Console.WriteLine();
    }


    /// <summary>
    /// Compares two lists of <see cref="Product"/> objects to determine if their details have changed.
    /// </summary>
    /// <remarks>
    /// This method uses the <see cref="ProductComparer"/> to compare two lists of <see cref="Product"/> objects.
    /// It checks if the products in the updated list are equal to those in the original list based on their 
    /// name and description. If any differences are found, a message indicating the changes is displayed.
    ///
    /// Article Reference:
    /// https://tomjones.dev/blog/handling-list-comparisons-in-net-with-iequalitycomparer/
    /// - code samples have issues
    /// - Karen changed the code samples to work correctly and conformed to <see cref="FirstNameLastNameBirthDateEqualityComparer"/>
    /// </remarks>
    private static void CompareProducts()
    {
        var originalProducts = new List<Product>()
        {
            new() { Id = 1, Name = "ProductName1", Description = "ProductDescription1", Price = 199.99f },
            new() { Id = 2, Name = "ProductName2", Description = "ProductDescription2", Price = 29.99f },
        };

        var updatedProducts = new List<Product>()
        {
            new() { Id = 1, Name = "ProductName1", Description = "UpdatedProductDescription1", Price = 199.99f },
            new() { Id = 2, Name = "UpdatedProductName2", Description = "ProductDescription2", Price = 29.99f },
        };

        AnsiConsole.MarkupLine("[bold]Products SequenceEqual[/]");

        var productDetailsHaveChanged = !updatedProducts.SequenceEqual(originalProducts, new ProductComparer());

        if (productDetailsHaveChanged)
        {
            AnsiConsole.MarkupLine("    [bold DeepPink3]Product details have changed:[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("    [bold DeepPink3]Product details have not changed.[/]");
        }


        Console.WriteLine();
    }

}

