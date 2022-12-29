using FluentValidation;
using VolleyballClub.Application.CQRS.Product.Commands.Add;

namespace VolleyballClub.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("{PropertyName} can not be empty");
            RuleFor(c => c.Price).NotEmpty().WithMessage("{PropertyName} can not be empty").ExclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");
            RuleFor(c => c.Stock).NotEmpty().WithMessage("{PropertyName} can not be empty").ExclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");
        }
    }
}
