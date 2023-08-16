using FluentAssertions;
using Service;
using TechTalk.SpecFlow;

namespace BDDTestLibrary.Steps;

//binding attribute needed so that feature file picks up steps
[Binding] 
public class LoggedDiscountSteps
{
    //you're able to inject this if you want
    private User _user;
    private Basket _basket;
    private readonly IPricingService _pricingService = new PricingService();
    private List<Product> _products;
    
    [Given(@"a user that is not logged in")]
    public void GivenAUserThatIsNotLoggedIn()
    {
        _user = new User() { IsLoggedIn = false };
    }

    [Given(@"an empty basket")]
    public void GivenAnEmptyBasket()
    {
        _basket = new Basket()
        {
            User = _user
        };
    }
    
    [Given(@"a user that is logged in")]
    public void GivenAUserThatIsLoggedIn()
    {
        _user = new User() { IsLoggedIn = true };
    }
    // Notice here how we're going to parameterise the steps so that it covers both scenarios using Regex
    // All squiggles in feature file should disappear when using the regex as given below instead of shirt
    //[When(@"a tshirt that costs (.*) GBP is added to the basket")]
    //original when step replaced with a more generic check which covers both test scenarios
    [When(@"a (.*) that costs (.*) GBP is added to the basket")]
    public void WhenAtShirtThatCostsGbpIsAddedToTheBasket(string itemName, decimal price)
    {
        _basket.Products.Add(new Product{Name = itemName, Price = price});
    }

    [Then(@"the basket value is (.*) GBP")]
    public void ThenTheBasketValueIsGbp(decimal expectedPrice)
    {
        var basketValue = _pricingService.GetBasketTotalAmount(_basket);
        basketValue.Should().Be(expectedPrice);

    }
    
    
}