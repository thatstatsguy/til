using PollyWalkthrough.Baseline;
using PollyWalkthrough.Caching;
using PollyWalkthrough.ExponentialBackoff;
using PollyWalkthrough.ExponentialBackoffWithJitter;
using PollyWalkthrough.RateLimit;
using PollyWalkthrough.Retries;
using PollyWalkthrough.SelfBakedTransientFailure;

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

app
    .AddBaselineEndpoints()
    .AddExponentialBackoffEndpoints()
    .AddExponentialBackoffWithJitterEndpoints()
    .AddCachingBackEndpoints()
    .AddRateLimitEndpoints()
    .AddRetryEndpoints()
    .AddCustomEndpoints();

app.Run();

