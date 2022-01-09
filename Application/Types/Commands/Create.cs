using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Types.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Types.Commands
{
    public class Create
    {
        public class Command : IRequest<Result<TypeDto>>
        {
            public TypeCreateDto TypeCreate { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.TypeCreate).SetValidator(new TypeValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<TypeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TypeDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.TypeCreate.State = true;
                var type = _mapper.Map<Type>(request.TypeCreate);
                await _context.Types.AddAsync(type, cancellationToken);
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                if (!result) return Result<TypeDto>.Failure("Error al crear el tipo");

                var typeDto = await _context.Types
                    .ProjectTo<TypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(t => t.Id == type.Id, cancellationToken);
                return Result<TypeDto>.Success(typeDto);
            }
        }
    }
}