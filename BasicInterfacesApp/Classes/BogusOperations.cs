using BasicInterfacesApp.Models;
using Bogus;
using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Models;
using static Bogus.Randomizer;
using Person = BasicInterfacesApp.Models.Person;
namespace BasicInterfacesApp.Classes;
internal class BogusOperations
{
    public static List<Person> CreatePeopleList(int count, bool random = true)
    {
        if (!random)
        {
            Seed = new Random(338);
        }

        var id = 1;

        var faker = new Faker<Person>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDate, u => u.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>());

        return faker.Generate(count);

    }

    public static List<Customer> CreateCustomerList(int count, bool random = true)
    {
        if (!random)
        {
            Seed = new Random(338);
        }

        var id = 1;

        var faker = new Faker<Customer>()
            .RuleFor(c => c.Id, f => id++)
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDate, u => u.Date.BetweenDateOnly(new DateOnly(1950, 1, 1), new DateOnly(2010, 1, 1)))
            .RuleFor(c => c.Gender, f => f.PickRandom<Gender>())
            .RuleFor(c => c.AccountType, f => f.PickRandom("Basic", "Premium", "VIP"));
            

        return faker.Generate(count);

    }
}
