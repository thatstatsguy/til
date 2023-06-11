using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecks.Health;

public class AzureFunctionHealthChecks : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var functionAppUrl = "https://<FunctionAppHostName>.azurewebsites.net/api/TestMe?code=<FunctionKey>";

            var stringContent =
                new StringContent("{'Name':'Test'}", Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            
            using var httpResponseMessage = 
                await 
                    client.PostAsync(functionAppUrl, stringContent);
            
            return HealthCheckResult.Healthy();

        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy(exception: e);
        }
        
    }
}