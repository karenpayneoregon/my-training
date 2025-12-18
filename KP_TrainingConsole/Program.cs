using KP_TrainingConsole.Classes;
using Spectre.Console;


namespace KP_TrainingConsole;
internal partial class Program
{
    static void Main(string[] args)
    {

        var birthDate = Prompts.GetDate();
        Console.WriteLine(birthDate);
        SpectreConsoleHelpers.ExitPrompt();
    }

}
