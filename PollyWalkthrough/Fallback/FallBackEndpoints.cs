using Microsoft.AspNetCore.Mvc;

namespace PollyWalkthrough.Fallback;

public static class FallBackEndpoints
{
    public static WebApplication AddFallBackEndpoints(this WebApplication app)
    {
        app.MapGet("/FallBack", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}