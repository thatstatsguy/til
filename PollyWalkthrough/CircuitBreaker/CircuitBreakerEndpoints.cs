using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.CircuitBreaker;

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