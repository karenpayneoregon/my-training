namespace AssertionApp;

internal class Program
{
    static void Main(string[] args)
    {
 
        
        string birthDate = Console.ReadLine();

        if (DateOnly.TryParse(birthDate, out var result))
        {
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine($"Invalid Date: {birthDate}");
        }


            Console.ReadLine();
    }
}
