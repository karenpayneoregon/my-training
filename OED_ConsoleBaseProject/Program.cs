using OED_ConsoleBaseProject.Classes;
using Serilog;
using Spectre.Console;

namespace OED_ConsoleBaseProject;
internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[bold green]OED [Console] Base Project[/]");
        SpectreConsoleHelpers.ExitPrompt();
    }
}
