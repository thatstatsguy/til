using HealthChecks.Data;
using HealthChecks.Health;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//add health checks
builder.Services.AddHealthChecks()
    .AddCheck<AzureFunctionHealthChecks>("AzureFunction")
    .AddCheck<GrpcHealthCheck>("GRPC Service");
    //To add health check for SQL Server
    //.AddSqlServer("<AddSqlServerConnectionString>");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app
    .MapHealthChecks("/_health", new HealthCheckOptions()
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        
    })
    //change to foolocalhost to stop local testing from taking place
    .RequireHost("localhost");

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
