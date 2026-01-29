

using InterfaceLibrary.Interfaces;
using InterfaceLibrary.Models;

namespace BasicInterfacesApp.Models;
public class Customer : IBaseEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public Gender Gender { get; set; }
    public Language Language { get; set; }
    public string AccountType { get; set; }
}