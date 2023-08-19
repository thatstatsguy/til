namespace MinimalApis.Simple;

public static class SimpleAddition
{
    

    public static WebApplication AddSimpleEndPoints(this WebApplication app)
    {
        app.MapGet("/Simple/Add", (int number1, int number2) =>
        {
            var calculator = new Calculator();
            return calculator.Add(number1, number2);
        });
        app.MapGet("/Simple/AddAlternative/{number1}/{number2}", (int number1, int number2) =>
        {
            var calculator = new Calculator();
            return calculator.Add(number1, number2);
        });

        app.MapPost("/Simple/AddWithPost", (NumbersToAdd numbers) =>
        {
            var calculator = new Calculator();
            return calculator.Add(numbers.Number1, numbers.Number2);
        });
            
        return app;
    }
    
}