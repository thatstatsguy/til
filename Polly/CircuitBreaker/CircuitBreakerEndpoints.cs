using Microsoft.AspNetCore.Mvc;

namespace Polly.CircuitBreaker;

public static class CircuitBreakerEndpoints
{
    public static WebApplication AddCircuitBreakerEndpoints(this WebApplication app)
    {
        app.MapGet("/CircuitBreaker", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}