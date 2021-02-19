﻿using FluentValidation;

namespace CleanArchitecture.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(v => v.Name).MaximumLength(50).NotEmpty();
        }
    }
}
