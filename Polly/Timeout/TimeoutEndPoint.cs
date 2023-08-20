using Microsoft.AspNetCore.Mvc;

namespace Polly.Timeout;

public static class TimeoutEndPoint
{
    public static WebApplication AddTimeoutEndpoints(this WebApplication app)
    {
        app.MapGet("/Timeout", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}