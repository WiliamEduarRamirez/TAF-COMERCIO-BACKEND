using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.DTOs;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories.Commands
{
    public class Create
    {
        public class Command : IRequest<Result<CategoryDto>>
        {
            public CategoryCreatedDto CategoryCreated { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CategoryCreated).SetValidator(new CategoryValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<CategoryDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<CategoryDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.CategoryCreated.State = true;
                request.CategoryCreated.Id = Guid.NewGuid();
                var category = _mapper.Map<Category>(request.CategoryCreated);
                await _context.Categories.AddAsync(category, cancellationToken);
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;
                
                if (!result) return Result<CategoryDto>.Failure("Error al crear la categoria");
                
                var categoryDto = await _context.Categories
                    .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == category.Id, cancellationToken);
                return Result<CategoryDto>.Success(categoryDto);
            }
        }
    }
}