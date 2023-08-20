using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.RateLimit;
using Newtonsoft.Json;

namespace PollyWalkthrough.RateLimit;

public static class RateLimitEndpoint
{
    //polly will fail on the second execution within a minute
    private static  AsyncRateLimitPolicy _rateLimitPolicy =
        Policy.RateLimitAsync(2, TimeSpan.FromMinutes(1));
            
    public static WebApplication AddRateLimitEndpoints(this WebApplication app)
    {
        app.MapGet("/RateLimit", async (HttpContext context, [FromServices] IHttpClientFactory clientFactory) =>
        {
            //https://github.com/App-vNext/Polly/tree/main#rate-limit
            try
            {
                var client = clientFactory.CreateClient("boredapi");
                var response = await _rateLimitPolicy.ExecuteAsync(() => client.GetAsync("activity"));
                var activityToDo = await response.Content.ReadAsStringAsync();
                await context.Response.WriteAsJsonAsync(JsonConvert.SerializeObject(activityToDo));
            }
            catch (RateLimitRejectedException e)
            {
                context.Response.StatusCode = 429;
                context.Response.Headers["Retry-After"] = ((int)e.RetryAfter.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
            }
            catch (Exception)
            {
            
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(
                    JsonConvert.SerializeObject("Houston, we got a problem"));
            }
        });
            
        return app;
    }
}