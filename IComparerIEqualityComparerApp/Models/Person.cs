
// ReSharper disable NonReadonlyMemberInGetHashCode
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
namespace IComparerIEqualityComparerApp.Models;

/// <summary>
/// Represents a person with properties for identification, name, and birthdate.
/// </summary>
public class Person : IEquatable<Person>
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    
    public bool Equals(Person compareTo)
        => (FirstName == compareTo!.FirstName &&
            LastName == compareTo.LastName &&
            BirthDate == compareTo.BirthDate);

    public override int GetHashCode()
        => HashCode.Combine(FirstName, LastName, BirthDate);
    
    public override string ToString() => $"{Id,-5}{FirstName} {LastName} {BirthDate:MM/dd/yyyy}";
}
