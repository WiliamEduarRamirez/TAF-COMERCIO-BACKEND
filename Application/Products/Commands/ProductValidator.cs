using Application.Products.DTOs;
using FluentValidation;

namespace Application.Products.Commands

{
    public class ProductValidator : AbstractValidator<ProductCreatedDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Denomination).NotEmpty().WithMessage("Nombre es requerido");
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.Stock).NotEmpty().NotNull();
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Categoria es requerido");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Tipo es requerido");
        }
    }
}