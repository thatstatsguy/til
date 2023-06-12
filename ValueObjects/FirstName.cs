namespace ValueObjects;

public class FirstName : ValueObject
{
    private const int MaxLength = 50;
    
    private FirstName(string value)
    {
        Value = value;
    }

    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<FirstName, Error> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return new Error("FirstName is empty");
        }

        if (firstName.Length > MaxLength)
        {
            return new Error("FirstName is too long");
        }

        return new FirstName(firstName);
    }
}