using MiddlewareTesting.Interfaces;

namespace MiddlewareTesting.Services;

public class UserTracker : IUserTracking
{
    public void CaptureUserIpAddress(string ip)
    {
        //can be redirected to sink or whatever else makes sense
        Console.WriteLine($"User at ip {ip} accessed the API");
    }
}