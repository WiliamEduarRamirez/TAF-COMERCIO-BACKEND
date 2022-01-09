using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Products.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Products.Commands

{
    public class ChangeStatus
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public ProductPatchDto ProductPatch { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductPatch.State)
                    .NotNull()
                    .WithMessage("Campo estado no puede ser vacio");
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
                var product = await _context.Products.FindAsync(request.Id);

                if (product == null)
                {
                    return Result<Unit>.NotFound("El producto no existe");
                }

                if (product.State == request.ProductPatch.State)
                {
                    return Result<Unit>.Failure("El estado no puede ser el mismo que el anterior");
                }

                _mapper.Map(product, product);
                product.State = request.ProductPatch.State;

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                return !result
                    ? Result<Unit>.Failure("Error al editar el estado del producto")
                    : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}