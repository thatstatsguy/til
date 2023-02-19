namespace bunit_examples;

using Bunit;
using Xunit;
using Pages;
using Moq;

public class CounterShould : TestContext
{
    [Fact]
    public void ShowCorrectHeading()
    {
        var cut = RenderComponent<Counter>();
        cut.Find("h1").MarkupMatches("<h1>Counter</h1>");
    }

    [Fact]
    public void IncrementCounterWhenClickMeClicked()
    {
        var cut = RenderComponent<Counter>();
        var button = cut.Find("button");
        button.Click();

        cut.Find("p").MarkupMatches("""<p role="status">Current count: 1</p>""");

    }
}

public class SpecialCounterShould : TestContext
{
    [Fact]
    public void UseInjectedParameterAndDependency()
    {
        var mockMathEngine = new Mock<IMathEngine>();
        mockMathEngine
            .Setup(x => x.IsAPrime(It.IsAny<int>()))
            .Returns(false);
        
        Services.AddSingleton<IMathEngine>(mockMathEngine.Object);

        var cut = RenderComponent<SpecialCounter>(parameters => 
            parameters
                .Add(p => p.Name, "TestUser"));
        
        //test that we've succesfully injected a parameter
        cut.Find("h1").MarkupMatches("<h1>TestUser's Counter</h1>");
        
        
        var button = cut.Find("button");
        button.Click();
        //testing that the counter still works
        cut
            .FindAll("p")
            .First(x=> x.InnerHtml.Contains("count"))
            .MarkupMatches("""<p role="status">Current count: 1</p>""");
        
        //testing that our injected dependency works as expected.
        cut
            .FindAll("p")
            .First(x=> x.InnerHtml.Contains("prime number"))
            .MarkupMatches("""<p role="status">Is a prime number? False""");
    }

}