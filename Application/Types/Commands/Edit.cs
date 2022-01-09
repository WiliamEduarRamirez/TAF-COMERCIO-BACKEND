using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Types.DTOs;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Types.Commands
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TypeCreateDto TypeUpdate { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TypeUpdate).SetValidator(new TypeValidator());
            }
        }
        
        public class Handler: IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context,IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var type = await _context.Types.FindAsync(request.TypeUpdate.Id);

                if (type == null) return Result<Unit>.NotFound("El tipo no existe");

                var typeUpdated = _mapper.Map<Type>(request.TypeUpdate);

                _mapper.Map(typeUpdated, type);
                
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Error al editar el tipo") : Result<Unit>.Success(Unit.Value);
            }
        }
            
    }
}