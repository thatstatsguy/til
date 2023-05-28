namespace MutationTesting.Tests;

public class CalculatorShould
{
    [Fact]
    public void DivideTwoNumbers2()
    {
        var actual = Calculator.Divide(1, 1);
        Assert.Equal(1, actual);   
    }
}