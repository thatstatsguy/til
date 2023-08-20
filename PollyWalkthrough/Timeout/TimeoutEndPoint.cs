using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.Timeout;

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