using MiddlewareTesting.Interfaces;

namespace MiddlewareTesting.Middleware;

public class UserOriginTracker : IMiddleware
{
    private readonly IUserTracking _userTracking;
    public UserOriginTracker(IUserTracking userTracking)
    {
        _userTracking = userTracking;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        //options to getting the user information. Haven't explored this avenue too much.
        //https://stackoverflow.com/questions/735350/how-to-get-a-users-client-ip-address-in-asp-net
        //https://stackoverflow.com/questions/27132908/userhostaddress-in-asp-net-core
        //https://stackoverflow.com/questions/28664686/how-do-i-get-client-ip-address-in-asp-net-core
        
        
        //According to comments on the post below - seeing ::1 just indicates you're testing on your
        //local machine which is normal
        //https://stackoverflow.com/questions/28664686/how-do-i-get-client-ip-address-in-asp-net-core
        var connectingClientIp = context.Connection.RemoteIpAddress?.ToString() ?? "";
        _userTracking.CaptureUserIpAddress(connectingClientIp);
        await next(context);
    }
}