namespace ControllerTests.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open ControllerTests

[<ApiController>]
[<Route("[controller]")>]
type WeatherForecastController (logger : ILogger<WeatherForecastController>) =
    inherit ControllerBase()

    let summaries =
        [|
            "Freezing"
            "Bracing"
            "Chilly"
            "Cool"
            "Mild"
            "Warm"
            "Balmy"
            "Hot"
            "Sweltering"
            "Scorching"
        |]

    [<HttpGet>]
    member ___.Get() : IActionResult =
        let rng = System.Random()
        let result = 
            [|
                for index in 0..4 ->
                    { Date = DateTime.Now.AddDays(float index)
                      TemperatureC = rng.Next(-20,55)
                      Summary = summaries.[rng.Next(summaries.Length)] }
            |]
        base.Ok(result)
        