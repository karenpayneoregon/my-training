using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Models;

namespace BasicInterfacesApp.Models;

public class Person : IBaseEntity
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Language Language { get; set; }
}