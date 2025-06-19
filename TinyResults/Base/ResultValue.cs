using System.Diagnostics.CodeAnalysis;

namespace TinyResults.Base;

public class Result<T> : Result
{
    private Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Value = value;
    }
    private Result(bool isSuccess, Error error) : base(isSuccess, error)
    {
    }

    private Result(bool isSuccess, Error[] errors) : base(isSuccess, errors)
    {
    }
    
    public T? Value { get; } 
    
    [MemberNotNullWhen(true, nameof(Value))]
    public override bool HasValue => IsSuccess;
    public static Result<T> Success(T value) => new(value, true, Error.None); 
    
    public new static Result<T> Failure(Error error) => new(false, error);
    
    public new static Result<T> Failure(Error[] errors) => new (false, errors);
    
    public static implicit operator Result<T>(T value) => Success(value);
}