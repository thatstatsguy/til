

using Microsoft.AspNetCore.Mvc;
using MinimalApis.Simple;

namespace MinimalApis.WithDI;

public static class AdditionWithDependencyInjection
{

    public static WebApplication AddDependencyInjectionRelatedEndPoints(this WebApplication app)
    {
        app.MapGet("/DI/Add", (int number1, int number2, [FromServices] ICalculator calculator) => 
            calculator.Add(number1, number2));
        return app;
    }
    
}