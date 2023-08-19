using Microsoft.AspNetCore.Rewrite;
using MiddlewareTesting.Interfaces;
using MiddlewareTesting.Middleware;
using MiddlewareTesting.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserTracking, UserTracker>();
builder.Services.AddTransient<UserOriginTracker>();
builder.Services.AddTransient<ReRouteV3Traffic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<UserOriginTracker>();
app.UseMiddleware<ReRouteV3Traffic>();

var options = new RewriteOptions()
    .AddRewrite(@"v1", "v2",
        skipRemainingRules: true);
app.UseRewriter(options);
app.MapGet("/ping", () => "pong");
app.MapGet("/v2", () => "You have arrived at the V2 endpoint!");
app.MapGet("/v4", () => "You have arrived at the V4 endpoint!");

app.Run();