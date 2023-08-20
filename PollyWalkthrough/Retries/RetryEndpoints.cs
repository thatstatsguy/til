using System.Net;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace PollyWalkthrough.Retries;

public static class RetryEndpoints
{
    private static readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy =
        Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(response =>
                response.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
            //retry up to 5 times
            .RetryAsync(5);

    public static WebApplication AddRetryEndpoints(this WebApplication app)
    {
        app.MapGet("/Retry", async ([FromServices] IHttpClientFactory clientFactory) =>
        {
            var client = clientFactory.CreateClient("boredapi");
            var response = 
                await _retryPolicy
                    .ExecuteAsync(() => client.GetAsync("activity"));
            return response.Content.ReadAsStringAsync();

        });
            
        return app;
    }
}