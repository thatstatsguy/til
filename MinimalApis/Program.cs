using FluentValidation;
using MinimalApis.Baseline;
using MinimalApis.Simple;
using MinimalApis.WithDI;
using MinimalApis.WithValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ICalculator, Calculator>();
builder.Services.AddSingleton<IValidator<NumbersToAddClass>, AdditionValidator>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddWeatherForecastEndpoints();
app.AddSimpleEndPoints();
app.AddDependencyInjectionRelatedEndPoints();
app.AddValidationEndPoints();
app.Run();


