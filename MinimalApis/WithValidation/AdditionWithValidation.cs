using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MinimalApis.Simple;

namespace MinimalApis.WithValidation;

public static class AdditionWithValidation
{
    public static WebApplication AddValidationEndPoints(this WebApplication app)
    {
        app.MapPost("/Validation/Add", ([FromBody] NumbersToAddClass numbers, [FromServices] IValidator<NumbersToAddClass> validator) =>
        {
            var validationResult = validator.Validate(numbers);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }
            var calculator = new Calculator();
            return Results.Ok(calculator.Add(numbers.Number1, numbers.Number2??0));
        });
            
        return app;
    }
}