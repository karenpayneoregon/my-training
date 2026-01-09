using IComparerIEqualityComparerApp.Models;

namespace IComparerIEqualityComparerApp.Classes.Comparers;

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person left, Person? right) 
        => string.Compare(left.LastName, right.LastName, StringComparison.Ordinal);
}