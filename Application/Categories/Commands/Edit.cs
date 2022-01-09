using System.Threading;
using System.Threading.Tasks;
using Application.Categories.DTOs;
using Application.Common.Models;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Categories.Commands
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CategoryCreatedDto CategoryUpdated { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CategoryUpdated).SetValidator(new CategoryValidator());
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
                var category = await _context.Categories.FindAsync(request.CategoryUpdated.Id);
                if (category == null) return Result<Unit>.NotFound("La categoria no existe");

                var categoryUpdated = _mapper.Map<Category>(request.CategoryUpdated);

                _mapper.Map(categoryUpdated, category);

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Error al editar la categoria") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}