using FluentValidation;

namespace ToDoApp.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(200).NotEmpty();
            RuleFor(v => v.Price).NotEmpty();
            RuleFor(v => v.OriginalPrice).NotEmpty();
            RuleFor(v => v.Stock).NotEmpty();
        }
    }
}
