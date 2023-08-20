using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.ExponentialBackoff;

public static class ExponentialBackoffEndpoints
{
    public static WebApplication AddExponentialBackoffEndpoints(this WebApplication app)
    {
        app.MapGet("/ExponentialBackoff", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}