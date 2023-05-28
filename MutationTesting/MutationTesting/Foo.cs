namespace MutationTesting;

public class Foo
{
    int min = 999;

    public int Bar(int number)
    {
        if (number < min)
        {
            min = number;
        }

        return min;
    }
}