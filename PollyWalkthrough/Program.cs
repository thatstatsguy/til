using PollyWalkthrough.Baseline;
using PollyWalkthrough.CircuitBreaker;
using PollyWalkthrough.ExponentialBackoff;
using PollyWalkthrough.ExponentialBackoffWithJitter;
using PollyWalkthrough.Fallback;
using PollyWalkthrough.RateLimit;
using PollyWalkthrough.Retries;
using PollyWalkthrough.SelfBakedTransientFailure;
using PollyWalkthrough.Timeout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("boredapi",
    client =>
    {
        client.BaseAddress = new Uri("https://www.boredapi.com/api/");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddBaselineEndpoints();
app.AddCircuitBreakerEndpoints();
app.AddExponentialBackoffEndpoints();
app.AddExponentialBackoffWithJitterEndpoints();
app.AddCachingBackEndpoints();
app.AddRateLimitEndpoints();
app.AddRetryEndpoints();
app.AddCustomEndpoints();
app.AddTimeoutEndpoints();

app.Run();

