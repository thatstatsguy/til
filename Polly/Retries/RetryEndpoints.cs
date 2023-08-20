using Microsoft.AspNetCore.Mvc;

namespace Polly.Retries;

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