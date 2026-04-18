using AspNet1.Dtos;
using FluentValidation;

namespace AspNet1.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.Title)
            .NotEmpty().WithMessage("Title is required")
            .Length(3, 50).WithMessage("Name must be between 3 and 50 characters");
        RuleFor(o => o.Description)
            .NotEmpty().WithMessage("Description is required");
        RuleFor(o => o.Quantity)
            .InclusiveBetween(1, 100).WithMessage("Quantity must be between 1 and 100");
    }
}