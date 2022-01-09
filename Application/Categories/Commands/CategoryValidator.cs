using Application.Categories.DTOs;
using FluentValidation;

namespace Application.Categories.Commands
{
    public class CategoryValidator:AbstractValidator<CategoryCreatedDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Denomination).NotEmpty().WithMessage("Nombre es requerido");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Tipo es requerido");
        }
    }
}