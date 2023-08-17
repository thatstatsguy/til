using TechTalk.SpecFlow;

namespace BDDTestLibrary.Tests.ComplexExample;

[Binding]
public class ComplexLoggedInDiscountHooks
{
    [BeforeFeature(Order=1)]
    public static void PreFeatureStepOne()
    {
        Console.WriteLine("Discovering new ways of making you wait");
    }
    
    [BeforeFeature(Order=2)]
    public static void PreFeatureStepTwo()
    {
        Console.WriteLine("Computing chance of success");
    }
    [BeforeFeature(Order=3)]
    public static void PreFeatureStepThree(FeatureContext featureContext)
    {
        Console.WriteLine($"About to run {featureContext.FeatureInfo.Title}");
    }
    
    [AfterFeature(Order = 1)]
    public static void PostFeatureStep1()
    {
        Console.WriteLine("Finding ways to let you know this test will fail");
    }
}