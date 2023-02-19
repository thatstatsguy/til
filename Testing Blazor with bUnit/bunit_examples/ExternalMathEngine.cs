namespace bunit_examples;

public class ExternalMathEngine : IMathEngine
{
    /// For the demo, I'm only implementing 
    /// logic for the first button click
    public bool IsAPrime(int input)
    {
        return input switch{
            1 => true,
            _ => false
        };
    }
}