using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Products.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Products.Queries
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ProductDto>>>
        {
            public ProductParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ProductDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<ProductDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Products
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                if (request.Params.IsEnable)
                {
                    queryable = queryable.Where(x => x.State);
                }

                if (!(request.Params.TypeId == null))
                {
                    queryable = queryable.Where(x => x.TypeId == request.Params.TypeId);
                }

                if (!(request.Params.CategoryId == null))
                {
                    queryable = queryable.Where(x => x.CategoryId == request.Params.CategoryId);
                }

                return Result<PagedList<ProductDto>>.Success(
                    await PagedList<ProductDto>.CreateAsync(queryable, request.Params.PageNumber,
                        request.Params.PageSize)
                );
            }
        }
    }
}