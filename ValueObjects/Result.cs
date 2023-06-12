namespace ValueObjects;
//source : https://www.youtube.com/watch?v=YbuSuSpzee4
public readonly struct Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    private Result(TValue value)
    {
        IsError = false;
        _value = value;
        _error = default;
    }
    
    private Result(TError error)
    {
        IsError = true;
        _error = error;
        _value = default;
    }

    public bool IsError { get; }

    public bool IsSuccess => !IsError;
    
    //allows you to return TValue or TError for a method returning Result<TValue, TError>
    //and it implicitly know to convert it
    public static implicit operator Result<TValue, TError>(TValue value) => new (value);
    public static implicit operator Result<TValue, TError>(TError error) => new (error);
    
    //allows you to match on success or failure
    public TResult Match<TResult>(
        Func<TValue, TResult> success, 
        Func<TError, TResult> failure) =>
        !IsError ? success(_value!) : failure(_error!);
}