using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos.Commands
{
    public class SetMain
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string PhotoId { get; set; }
            public Guid ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products
                    .Include(x => x.Photos)
                    .FirstOrDefaultAsync(x => x.Id == request.ProductId, cancellationToken);

                if (product == null) return Result<Unit>.NotFound("El producto no existe");

                var photo = product.Photos.FirstOrDefault(x => x.Id == request.PhotoId);

                if (photo == null)
                    return Result<Unit>.NotFound(
                        "El producto no tiene ninguna foto asociada con ese id, La foto no existe");

                var currentMain = product.Photos.FirstOrDefault(x => x.IsMain);

                if (currentMain != null) currentMain.IsMain = false;

                photo.IsMain = true;

                var success = await _context.SaveChangesAsync(cancellationToken) > 0;

                return success
                    ? Result<Unit>.Success(Unit.Value)
                    : Result<Unit>.Failure("Ocurrio un problema al momento de cambiar la foto principal");
            }
        }
    }
}