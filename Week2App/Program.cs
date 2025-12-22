using System.Drawing;
using Week2App.Classes;

namespace Week2App;

internal class Program
{
    static void Main(string[] args)
    {
        var (grade, comment) = Samples.GetGradeWithRemarks(85);
        Console.WriteLine($"Grade: {grade}, Comment: {comment}");
        Console.WriteLine();
        
        Samples.TypeCheckingSample1("Hello");
        Console.WriteLine();
        
        Samples.TypeCheckingSample2(15);
        Console.WriteLine();
        
        Color seasonColor = Samples.GetSeasonColor(7);
        Console.WriteLine($"Season color: {seasonColor}");
        Console.WriteLine();
        
        Samples.EnumSample(Direction.East);
        Console.WriteLine();
        
        Person person = new("Alice", 17);
        Console.WriteLine($"Person category: {Samples.GetPersonCategory(person)}");

        Console.WriteLine();
        Console.WriteLine("Press ENTER to exit...");
        Console.ReadLine();
        
    }
}
