using Grpc.Health.V1;
using Grpc.Net.Client;
using Microsoft.Extensions.Diagnostics.HealthChecks;
namespace HealthChecks.Health;

public class GrpcHealthCheck : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Grpc.Health.V1.Health.HealthClient(channel);

            var response = await client.CheckAsync(new HealthCheckRequest());
            var status = response.Status;
            return status switch
            {
                HealthCheckResponse.Types.ServingStatus.Serving => HealthCheckResult.Healthy(),
                _ => HealthCheckResult.Unhealthy()
            };
        }
        catch (Exception e)
        {
            return HealthCheckResult.Unhealthy(exception: e);
        }
    }
}