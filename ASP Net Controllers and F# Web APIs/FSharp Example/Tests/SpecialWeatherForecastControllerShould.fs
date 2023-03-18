namespace ControllerTests

open System
open ControllerTests.Controllers
open Microsoft.AspNetCore.Mvc
open Xunit

module SpecialWeatherForecastControllerShould =
    
    [<Fact>]
    let ``Return dummy results specified in code``() =
        
        let controller = new SpecialWeatherForecastController()
        let response = controller.GiveMeAForecast() :?> OkObjectResult
        
        let expectedResult: WeatherForecast[] =
            [|
                {
                    Date = DateTime.Today
                    TemperatureC = 30
                    Summary = "Insert Summary here" }
            |]
        
        Assert.Equal(200, response.StatusCode.Value)
        
        Assert.Equal<WeatherForecast[]>(expectedResult, (response.Value :?> WeatherForecast[]))
        
        
        
        

