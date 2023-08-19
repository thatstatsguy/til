using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Caching.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddControllers();
builder.Services.AddOutputCache()
    .AddStackExchangeRedisCache(x =>
    {
        x.InstanceName = "AddingApi";
        x.Configuration = "localhost:6379";
    });
        
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseOutputCache();
app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.MapBlazorHub();

//Testing: http://localhost:5264/minimalendpoint
app.MapGet("/minimalendpoint", () =>
{
    return Results.Ok("Congrats! You found the minimal api endpoint");
});

//Testing: http://localhost:5264/minimaladd?number1=2&number2=3
app.MapGet("/minimaladd", (int number1, int number2) =>
    {
        return Results.Ok(number1 + number2);
    })
    .CacheOutput(x => x.Expire(TimeSpan.FromMinutes(5)))
    .WithName("test");

// {
//     Results.Ok("Congrats! You found the minimal api endpoint");
// });

app.MapFallbackToPage("/_Host");

app.Run();
