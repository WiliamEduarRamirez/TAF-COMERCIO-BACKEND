using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Products.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products.Commands
{
    public class Create
    {
        public class Command : IRequest<Result<ProductDto>>
        {
            public ProductCreatedDto ProductCreated { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ProductCreated).SetValidator(new ProductValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<ProductDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ProductDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.ProductCreated.State = true;
                request.ProductCreated.Id = Guid.NewGuid();
                var product = _mapper.Map<Product>(request.ProductCreated);
                await _context.Products.AddAsync(product, cancellationToken);
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!result) return Result<ProductDto>.Failure("Error al crear un producto");

                var productDto = await _context.Products
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == product.Id, cancellationToken: cancellationToken);
                
                return Result<ProductDto>.Success(productDto);
            }
        }
    }
}