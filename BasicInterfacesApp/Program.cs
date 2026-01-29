using BasicInterfacesApp.Classes;
using BasicInterfacesApp.Models;
using InterfaceLibrary.Models;

namespace BasicInterfacesApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        User user = new User()
        {
            FirstName = "John",
            LastName = "Doe"
        };
        //Person person = new Person();

        Taxpayer taxpayer = new Taxpayer()
        {
            FirstName = "", 
            LastName = ""
        };

        Customer customer = new Customer();
        
        var people = BogusOperations.CreatePeopleList(25);
        var customers = BogusOperations.CreateCustomerList(25);

        SpectreConsoleHelpers.ExitPrompt();
    }
}

