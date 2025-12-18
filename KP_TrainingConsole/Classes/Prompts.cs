using KP_TrainingConsole.Models;
using Spectre.Console;
using static System.Globalization.DateTimeFormatInfo;
using static System.DateTime;

namespace KP_TrainingConsole.Classes;
internal class Prompts
{
    // Default value style
    private static readonly Style Style = new(Color.Fuchsia, Color.Black, Decoration.None);


    /// <summary>
    /// Prompts the user to enter an integer value with a custom prompt message.
    /// </summary>
    /// <param name="prompt">The custom message displayed to the user when prompting for input.</param>
    /// <returns>
    /// The integer value entered by the user. If no input is provided, a default value of <c>1</c> is returned.
    /// </returns>
    public static int GetInt(string prompt = "Enter an integer") =>
        AnsiConsole.Prompt(
            new TextPrompt<int>($"[cyan]{prompt}[/]")
                .PromptStyle("yellow")
                .DefaultValue(1)
                .DefaultValueStyle(Style));

    /// <summary>
    /// Prompts the user to enter a decimal value with a custom prompt message.
    /// </summary>
    /// <param name="prompt">The custom message displayed to the user when prompting for input.</param>
    /// <returns>
    /// The decimal value entered by the user. If no input is provided, a default value of <c>1.0</c> is returned.
    /// </returns>
    public static decimal GetDecimal(string prompt = "Enter a decimal") =>
        AnsiConsole.Prompt(
            new TextPrompt<decimal>($"[cyan]{prompt}[/]")
                .PromptStyle("yellow")
                .DefaultValue(1.0m)
                .DefaultValueStyle(Style));

    /// <summary>
    /// Prompts the user to enter a date via the console.
    /// </summary>
    /// <param name="text">
    /// The text to display in the prompt, indicating what the user should enter. Defaults to "Enter a date".
    /// </param>
    /// <returns>
    /// A <see cref="DateOnly"/> value entered by the user, or <c>null</c> if the user chooses not to enter a date.
    /// </returns>
    public static DateOnly? GetDate(string text = "Enter a date") =>
        AnsiConsole.Prompt(new TextPrompt<DateOnly>($"[cyan]{text}[/]")
            .PromptStyle("yellow")
            .DefaultValueStyle(Style)
            .DefaultValue(DateOnly.FromDateTime(Today))
            .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
            .AllowEmpty());

    
    /// <summary>
    /// Prompts the user to select a month from a list of available months.
    /// </summary>
    /// <returns>
    /// A <see cref="MonthItem"/> representing the month selected by the user.
    /// </returns>
    /// <remarks>
    /// The method displays a selection prompt in the console, allowing the user to choose from a list of months.
    /// The list of months is dynamically generated based on the current culture's month names.
    /// </remarks>
    public static MonthItem PickMonth() =>
        AnsiConsole.Prompt(
            new SelectionPrompt<MonthItem>()
                .Title("Pick a month:")
                .PageSize(12)
                .UseConverter(m => m.Name)
                .AddChoices(GetMonthItems()));


    /// <summary>
    /// Generates a list of <see cref="MonthItem"/> objects representing the months of the year.
    /// </summary>
    /// <returns>
    /// A <see cref="List{T}"/> of <see cref="MonthItem"/> objects, where each item contains the month's
    /// numeric identifier (<see cref="MonthItem.Id"/>) and name (<see cref="MonthItem.Name"/>).
    /// </returns>
    /// <remarks>
    /// The method uses the current culture's month names to dynamically create the list of months.
    /// The last empty month name, if present, is excluded from the list.
    /// </remarks>
    private static List<MonthItem> GetMonthItems()
    {
        return CurrentInfo!.MonthNames[..^1]
            .Select((name, index) => new MonthItem
            {
                Id = index + 1, // 
                Name = name
            })
            .ToList();
    }
}
