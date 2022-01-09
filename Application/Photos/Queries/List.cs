using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Photos.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos.Queries
{
    public class List
    {
        public class Query : IRequest<Result<List<PhotoDto>>>
        {
            public Guid ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<PhotoDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<PhotoDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products
                    .FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);
                if (product == null)
                {
                    return Result<List<PhotoDto>>.NotFound("El producto no existe");
                }

                var photos = await _context.Photos
                    .Where(x => x.ProductId == request.ProductId)
                    .ProjectTo<PhotoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return Result<List<PhotoDto>>.Success(photos);
            }
        }
    }
}