using Microsoft.AspNetCore.Mvc;

namespace Polly.SelfBakedTransientFailure;

public static class CustomTransientFailureEndpoints
{
    public static WebApplication AddCustomEndpoints(this WebApplication app)
    {
        app.MapGet("/Custom", ([FromServices] IHttpClientFactory clientFactory) =>
        {

        });
            
        return app;
    }
}