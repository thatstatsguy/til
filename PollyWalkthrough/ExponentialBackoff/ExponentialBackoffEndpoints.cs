using System.Net;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace PollyWalkthrough.ExponentialBackoff;

public static class ExponentialBackoffEndpoints
{

    private static readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy =
        Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(response =>
                response.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
            .WaitAndRetryAsync(Backoff.ExponentialBackoff(TimeSpan.FromSeconds(1), 5));
    public static WebApplication AddExponentialBackoffEndpoints(this WebApplication app)
    {
        app.MapGet("/ExponentialBackoff", async ([FromServices] IHttpClientFactory clientFactory) =>
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