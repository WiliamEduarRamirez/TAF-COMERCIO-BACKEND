using System.Collections.Generic;
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
    public class List
    {
        public class Query : IRequest<Result<List<MemberDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<MemberDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<MemberDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _context.Users
                    .ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();

                return Result<List<MemberDto>>.Success(users);
            }
        }
    }
}