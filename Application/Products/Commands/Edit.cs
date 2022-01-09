using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Products.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Products.Commands

{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ProductCreatedDto ProductUpdated { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductUpdated).SetValidator(new ProductValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.ProductUpdated.Id);

                if (product == null) return Result<Unit>.NotFound("El producto no existe");

                var productUpdated = _mapper.Map<Product>(request.ProductUpdated);
                _mapper.Map(productUpdated, product);

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Error al editar el producto") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}