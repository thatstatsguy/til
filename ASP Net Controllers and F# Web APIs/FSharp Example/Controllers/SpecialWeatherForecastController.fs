namespace ControllerTests.Controllers

open System
open Microsoft.AspNetCore.Mvc
open ControllerTests

[<ApiController>]
[<Route("[controller]/[action]")>]
type SpecialWeatherForecastController() =
    inherit Controller()
    
    [<HttpGet>]
    member _.GiveMeAForecast() : IActionResult =
        let result =
            [|
                {
                    Date = DateTime.Today
                    TemperatureC = 30
                    Summary = "Insert Summary here" }
            |]
            
        base.Ok(result)
        
    

