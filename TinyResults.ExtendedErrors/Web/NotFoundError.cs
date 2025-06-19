using TinyResults.Base;

namespace TinyResults.ExtendedErrors.Web;

public record NotFoundError(string Description) : Error("404", Description)
{
}