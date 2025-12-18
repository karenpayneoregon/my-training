using System.Diagnostics;

namespace KP_TrainingConsole.Models;

[DebuggerStepThrough]
internal class MonthItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public override string ToString() => $"{Id}  {Name}";

}
