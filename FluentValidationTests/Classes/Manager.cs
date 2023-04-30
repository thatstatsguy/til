using FluentValidation;

namespace FluentValidationTests.Classes;

public class Manager
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    
    public int Age { get; set; }
}

public class ManagerValidator : AbstractValidator<Manager>
{
    public ManagerValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Manager name needs to be specified")
            .MaximumLength(50).WithMessage("Manager name cannot be longer than 50 characters");

        RuleFor(p => p.Surname)
            .NotEmpty().WithMessage("Manager surname needs to be specified")
            .MaximumLength(50).WithMessage("Last name cannot be longer than 50 characters");
        
        RuleFor(p => p.Age)
            .NotNull()
            .GreaterThan(0)
            .Must(IsAgeValid).WithMessage("Age is too high!");
    }
    
    /// <summary>
    /// Custom logic validation
    /// </summary>
    /// <param name="age"></param>
    /// <returns></returns>
    private static bool IsAgeValid(int age)
    {
        return age < 100;
    }
}