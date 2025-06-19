using TinyResults.Enums;

namespace TinyResults.Base;

public record Error(string Code, string Description, Severity SeverityLevel = Severity.None)
{
    public static readonly Error None = new(string.Empty, string.Empty);
}