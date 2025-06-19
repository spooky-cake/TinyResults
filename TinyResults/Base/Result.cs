namespace TinyResults.Base;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        
        IsSuccess = isSuccess;
        Errors = [error];
    }
    protected Result(bool isSuccess, Error[] errors)
    {
        if (isSuccess)
        {
            throw new ArgumentException("Invalid error", nameof(errors));
        }
        IsSuccess = isSuccess;
        Errors = errors;
    }
    public bool IsSuccess { get; }
    
    public bool IsFailure => !IsSuccess;
    
    public virtual bool HasValue => false;
    public Error[] Errors { get; } 
    
    public Error Error  => Errors.FirstOrDefault() ?? new Error("Undefined","Undefined Error");

    public static Result Success() => new(true, Error.None);
    
    public static Result Failure(Error error) => new(false, error);
    
    public static Result Failure(Error[] errors) => new(false, errors);
}