using Microsoft.AspNetCore.Mvc;
using Refit;
using refitwalkthrough;
using refitwalkthrough.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddRefitClient<IRandomStringGenerator>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://ciprand.p3p.repl.co"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/testwithoutDI", async () =>
{
    var boredApi = RestService.For<IActivity>("https://www.boredapi.com/api");
    return await boredApi.GetUser();
});

app.MapGet("/testwithDI", async ([FromServices] IRandomStringGenerator stringGenerator) =>
{
    //https://github.com/polarspetroll/ciprand
    var results = await stringGenerator.GetRandomStrings(10,1);
    return results;
});


app.Run();

