using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.DTOs;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class Details
    {
        public class Query : IRequest<Result<MemberDto>>
        {
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<MemberDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<MemberDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(x => x.UserName == request.Username)
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();

                return Result<MemberDto>.Success(user);
            }
        }
    }
}