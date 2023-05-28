namespace MutationTesting.Tests;

public class FizzShould
{
    [Fact]
    public void BuzzTest()
    {
        var exception = Assert.Throws<Exception>(() => Fizz.Buzz(5));
        
        Assert.Equal("Test", exception.Message);   
    }
}