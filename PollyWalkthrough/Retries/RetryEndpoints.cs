using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.Retries;

public static class RetryEndpoints
{
    public static WebApplication AddRetryEndpoints(this WebApplication app)
    {
        app.MapGet("/Retry", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}