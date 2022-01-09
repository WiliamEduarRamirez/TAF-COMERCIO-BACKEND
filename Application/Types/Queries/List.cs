using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using Application.Types.DTOs;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Persistence;

namespace Application.Types.Queries
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<TypeDto>>>
        {
            public TypeParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<TypeDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<PagedList<TypeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Types
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<TypeDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                if (request.Params.IsEnable)
                {
                    queryable = queryable.Where(x => x.State);
                }

                if (!string.IsNullOrEmpty(request.Params.Query))
                {
                    queryable = queryable.Where(x => x.Denomination.Contains(request.Params.Query));
                }

                return Result<PagedList<TypeDto>>.Success(
                    await PagedList<TypeDto>.CreateAsync(queryable, request.Params.PageNumber,
                        request.Params.PageSize)
                );
            }
        }
    }
}