using System.Reflection;
using BlazorSubscriber;
using BlazorSubscriber.Data;
using BlazorSubscriber.Messaging;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMassTransit(x =>
{
    // x.AddConsumer<RabbitMqSubscriber>();
    x.AddConsumer<GettingStartedConsumer>();
    x.UsingRabbitMq((context,cfg) =>
    {
        cfg.Host(host: "my-rabbit");
        cfg.ConfigureEndpoints(context);
    });
        
    
    //x.AddConsumers(typeof(Program).Assembly); //alternative is typeof(Program).GetAssembly
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

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
