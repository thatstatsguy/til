
namespace MiddlewareTesting.Middleware;

public class ReRouteV3Traffic : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        //technically not needed to do this as microsoft has this functionality, but fun
        //to try nonetheless. More info at the links below.
        //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting?view=aspnetcore-7.0
        //https://stackoverflow.com/questions/43607499/is-it-possible-to-redirect-request-from-middleware-in-net-core#:~:text=That%27s%20called%20URL%20Rewriting%20and%20ASP.NET%20Core%20already,can%20check%20source%20code%20and%20write%20your%20own.
        //https://github.com/ardalis/NotFoundMiddlewareSample/tree/master
        
        
        var currentPath = context.Request.Path.Value ?? "";
        //definitely use the rewrite method over this - using this method doesn't allow other middleware to be
        //called after this otherwise the redirect is ignored
        //https://stackoverflow.com/questions/43607499/is-it-possible-to-redirect-request-from-middleware-in-net-core
        if (currentPath == "/v3")
        {
            context.Response.Redirect("/v4");
        }
        else
        {
            await next(context);
        }

        
    }
}