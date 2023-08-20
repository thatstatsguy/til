using Polly.Baseline;
using Polly.CircuitBreaker;
using Polly.ExponentialBackoff;
using Polly.ExponentialBackoffWithJitter;
using Polly.Fallback;
using Polly.RateLimit;
using Polly.Retries;
using Polly.SelfBakedTransientFailure;
using Polly.Timeout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.AddFallBackEndpoints();
app.AddRateLimitEndpoints();
app.AddRetryEndpoints();
app.AddCustomEndpoints();
app.AddTimeoutEndpoints();

app.Run();

