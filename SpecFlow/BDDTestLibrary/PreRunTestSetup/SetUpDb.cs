using TechTalk.SpecFlow;

namespace BDDTestLibrary.PreRunTestSetup;
[Binding]
public class SetUpDb
{
    [BeforeTestRun]
    public static void SetupDb()
    {
        Console.WriteLine("Inserting interesting test data into db");
    }
    [AfterTestRun]
    public static void DeleteFixtureData()
    {
        Console.WriteLine("Making test data go bye bye");
    }
}