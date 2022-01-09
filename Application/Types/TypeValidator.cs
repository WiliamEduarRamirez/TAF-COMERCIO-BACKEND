using Application.Types.DTOs;
using FluentValidation;

namespace Application.Types
{
    public class TypeValidator:AbstractValidator<TypeCreateDto>
    {
        public TypeValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Denomination).NotEmpty().WithMessage("Nombre es requerido");
        }
    }
}