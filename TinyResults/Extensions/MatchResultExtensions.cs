using TinyResults.Base;

namespace TinyResults.Extensions;

public static class MatchResultExtensions
{
    public static T Match<T>(
        this Result result,
        Func<T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result.Error);
    }
    
    public static T Match<T>(
        this Result result,
        Func<T> onSuccess,
        Func<Error[], T> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result.Errors);
    }

    public static T Match<T, TResult>(
        this Result<TResult> result,
        Func<TResult, T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value!) : onFailure(result.Error);
    }
    
    public static T Match<T, TResult>(
        this Result<TResult> result,
        Func<TResult, T> onSuccess,
        Func<Error[], T> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value!) : onFailure(result.Errors);
    }
    
    public static void Match(
        this Result result,
        Action onSuccess,
        Action<Error> onFailure)
    {
        if (result.IsSuccess)
        {
            onSuccess();
        }
        else
        {
            onFailure(result.Error);
        }
    }
}