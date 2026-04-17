using AspNet1.Dtos;
using FluentValidation;

namespace AspNet1.Validators;

public class CreatePizzaValidator : AbstractValidator<CreatePizzaDto>
{
    public CreatePizzaValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Name is required")
            .Length(3, 50).WithMessage("Name must be between 3 and 50 characters");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage("Description is required");
        
        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required")
            .InclusiveBetween(1, 10000).WithMessage("Price must be between 1 and 10000");
            
    }
}