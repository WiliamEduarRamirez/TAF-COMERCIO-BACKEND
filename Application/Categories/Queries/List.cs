using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Categories.DTOs;
using Application.Common.Models;
using Application.Types.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories.Queries
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<CategoryDto>>>
        {
            public CategoryParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<CategoryDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<CategoryDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var type = await _context.Types.ProjectTo<TypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Params.TypeId, cancellationToken);
                
                if (type == null)
                {
                    Result<PagedList<CategoryDto>>.NotFound("El tipo no existe");
                }

                var queryable = _context.Categories
                    .OrderByDescending(x => x.CreatedAt)
                    .Where(x => x.TypeId == request.Params.TypeId)
                    .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                if (request.Params.IsEnable)
                {
                    queryable = queryable.Where(x => x.State);
                }

                if (!string.IsNullOrEmpty(request.Params.Query))
                {
                    queryable = queryable.Where(x => x.Denomination.Contains(request.Params.Query));
                }
                
                return Result<PagedList<CategoryDto>>.Success(
                    await PagedList<CategoryDto>.CreateAsync(queryable, request.Params.PageNumber,
                        request.Params.PageSize)
                );
            }
        }
    }
}