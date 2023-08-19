using MinimalApis.Simple;
using FluentValidation;

namespace MinimalApis.WithValidation;

public class AdditionValidator : AbstractValidator<NumbersToAddClass>
{
    public AdditionValidator()
    {
        RuleFor(x => x.Number1)
            .NotNull().WithMessage("Number 1 cannot be null");
        
        RuleFor(x => x.Number2)
            .NotNull().WithMessage("Number 2 cannot be null");
    }   
}