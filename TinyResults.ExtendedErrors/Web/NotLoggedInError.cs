using TinyResults.Base;

namespace TinyResults.Errors.Web;

public record NotLoggedInError(string Description = "Inicia sesión para continuar") : Error("401", Description);