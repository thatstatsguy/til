namespace MutationTesting;

public class Fizz
{
    public static void Buzz(int number1)
    {
        if (number1 <= 10)
        {
            throw new Exception("Test");
        }

        if (number1 >= 10)
        {
            Foo();
        }
    }

    private static void Foo()
    {
        
    }
}