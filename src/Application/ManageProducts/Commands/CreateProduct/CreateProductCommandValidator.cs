using FluentValidation;

namespace ToDoApp.Application.ManageProducts.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(200).NotEmpty();
            RuleFor(v => v.Price).NotEmpty();
            RuleFor(v => v.OriginalPrice).NotEmpty();
            RuleFor(v => v.Stock).NotEmpty();
        }
    }
}
