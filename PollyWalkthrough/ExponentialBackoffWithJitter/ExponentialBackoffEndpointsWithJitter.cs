using System.Net;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Contrib.WaitAndRetry;

namespace PollyWalkthrough.ExponentialBackoffWithJitter;

public static class ExponentialBackoffEndpointsWithJitter
{
    private static readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy =
        Policy<HttpResponseMessage>
            .Handle<HttpRequestException>()
            .OrResult(response =>
                response.StatusCode is >= HttpStatusCode.InternalServerError or HttpStatusCode.RequestTimeout)
            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5));

    public static WebApplication AddExponentialBackoffWithJitterEndpoints(this WebApplication app)
    {
        app.MapGet("/ExponentialBackoffWithJitter", async ([FromServices] IHttpClientFactory clientFactory) =>
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