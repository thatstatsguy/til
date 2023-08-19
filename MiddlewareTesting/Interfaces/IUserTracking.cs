namespace MiddlewareTesting.Interfaces;

public interface IUserTracking
{
    /// <summary>
    /// Method for capturing ip address for anyone trying to access the API
    /// </summary>
    public void CaptureUserIpAddress(string ip);
}