namespace ValueObjects;

/// Value object
/// In DDD, it's a type defined only by its values
/// two objects with the same values are equal under this def
/// Value objects are immutable by design
///
/// https://www.youtube.com/watch?v=P5CRea21R2E
public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();
    
    //everything below this enforces structural equality
    public bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEqual(other);
    }
    
    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
    public override int GetHashCode()
    {
        return
            GetAtomicValues()
                .Aggregate(default(int), HashCode.Combine);
    }
}