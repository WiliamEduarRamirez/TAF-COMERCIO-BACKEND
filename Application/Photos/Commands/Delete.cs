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
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string PhotoId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IPhotoAccessor photoAccessor, IUserAccessor userAccessor)
            {
                _context = context;
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                
                var photo = await _context.Photos.FirstOrDefaultAsync(x => x.Id == request.PhotoId, cancellationToken);

                if (photo == null) return Result<Unit>.NotFound("La foto no existe");

                if (photo.IsMain) return Result<Unit>.Failure("No puede eliminar esta foto porque es principal");

                var result = await _photoAccessor.DeletePhoto(photo.Id);

                if (result == null) return Result<Unit>.Failure("Problema al eliminar la foto en cloudnary");
                _context.Photos.Remove(photo);
                var success = await _context.SaveChangesAsync(cancellationToken) > 0;

                return success
                    ? Result<Unit>.Success(Unit.Value)
                    : Result<Unit>.Failure("Ocurrio un error al eliminar la foto");
            }
        }
    }
}