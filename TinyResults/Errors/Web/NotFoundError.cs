using TinyResults.Base;

namespace TinyResults.Errors.Web;

public record NotFoundError(string Description) : Error("404", Description)
{
}