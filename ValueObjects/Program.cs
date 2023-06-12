// See https://aka.ms/new-console-template for more information

using ValueObjects;

var firstNameResult = FirstName.Create("Test");


FirstName firstResult = firstNameResult.Match<FirstName>(
    success => success,
    error => throw new Exception(error.ErrorMessage));
    
Console.WriteLine($"First Result: {firstResult.Value}");

var secondNameResult = FirstName.Create("");

FirstName secondResult = secondNameResult.Match<FirstName>(
    success => success,
    error => throw new Exception(error.ErrorMessage));
    
Console.WriteLine(secondResult);
