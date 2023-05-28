namespace MutationTesting.Tests;

public class FooShould
{
    [Fact]
    public void BarTest()
    {
        var c = new Foo();
        var actual = c.Bar(1);
        Assert.Equal(1, actual);   
    }
}