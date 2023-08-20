using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.SelfBakedTransientFailure;

public static class CustomTransientFailureEndpoints
{
    public static WebApplication AddCustomEndpoints(this WebApplication app)
    {
        //for the record - I'm using goto's as this was used in Nicks video. As a general rule of thumb avoid
        //goto statements as avoiding it will (in general) lead to more readable code.
        //https://stackoverflow.com/questions/5485029/best-practice-for-using-goto
        
        app.MapGet("/custom", async ([FromServices] IHttpClientFactory clientFactory) =>
        {
            var client = clientFactory.CreateClient("boredapi");
            var retryCount = 0;
            Start:
            try
            {
                var response = await client.GetAsync("activity");
                if (response.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
                {
                    //i.e. we're dealing with a transient error
                    if (retryCount>=5)
                    {
                        return Results.BadRequest("Server Error - Too many retries attempted.");
                    }
                    retryCount++;
                    goto Start;    
                }

                return Results.Ok(await response.Content.ReadAsStringAsync());

            }
            catch (HttpRequestException)
            {
                if (retryCount>=5)
                {
                    return Results.BadRequest("Server Error - Too many retries attempted.");
                }
                retryCount++;
                goto Start;
            }

            return Results.BadRequest("This is awkward");
        });
            
        return app;
    }
}