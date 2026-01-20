using IncludeRuleSetsApp.Classes;
using IncludeRuleSetsApp.LanguageExtensions;
using IncludeRuleSetsApp.Models;

namespace IncludeRuleSetsApp;

internal partial class Program
{
    private static void Main(string[] args)
    {

        Examples();
        UsingExtensions();
        AnsiConsole.Write(new Rule("[yellow]Continue[/]"));

        Console.ReadLine();
    }

    private static void Examples()
    {
        Samples.ValidatePersonWithRuleSetsWildcard();
        Samples.ValidatePersonWithRuleSetsSpecific();
        Samples.ValidateAllPropertiesWithRuleSetsWildcard();
        Samples.ValidateForAddingRecordForEntityFrameworkCore();
    }

    private static void UsingExtensions()
    {
        AnsiConsole.MarkupLine($"[cyan]{nameof(UsingExtensions)}[/] Rules {nameof(RuleNames.Names)} and {nameof(RuleNames.Birth)}");

        var result1 = MockedData.ValidPerson.AllRules();
        Console.WriteLine($"All Rules Valid: {result1.IsValid.ToYesNo()}");

        var result2 = MockedData.InvalidPerson.AllRules();
        Console.WriteLine($"All Rules Valid for Invalid Person: {result2.IsValid.ToYesNo()}");

        var result3 = MockedData.InvalidPerson.SelectedRules(
            nameof(RuleNames.Names), 
            nameof(RuleNames.Birth));
        
        if (result3.IsValid)
        {
            
            Console.WriteLine("Selected rules are valid.");
        }
        else
        {
            Console.WriteLine("Selected rules are not valid.");
            result3.PrintErrors();
        }
    }
}