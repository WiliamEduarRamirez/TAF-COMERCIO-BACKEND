using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Photos.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos.Commands
{
    public class Add
    {
        public class Command : IRequest<Result<PhotoDto>>
        {
            public IFormFile File { get; set; }
            public Guid ProductId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<PhotoDto>>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IMapper _mapper;


            public Handler(DataContext context, IPhotoAccessor photoAccessor, IMapper mapper)
            {
                _context = context;
                _photoAccessor = photoAccessor;
                _mapper = mapper;
            }

            public async Task<Result<PhotoDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.ProductId);

                if (product == null)
                {
                    return Result<PhotoDto>.NotFound("El producto no existe");
                }

                var photoUploaderResult = await _photoAccessor.AddPhoto(request.File);

                var photo = new Photo
                {
                    Url = photoUploaderResult.Url,
                    Id = photoUploaderResult.PublicId,
                    IsMain = false,
                    Product = product
                };


                var existMain = await _context.Photos
                    .Where(x => x.ProductId == request.ProductId && x.IsMain)
                    .AnyAsync();

                if (!existMain) photo.IsMain = true;

                _context.Photos.Add(photo);

                /*product.Photos.Add(photo);*/

                var result = await _context.SaveChangesAsync() > 0;
                var photoDto = _mapper.Map<PhotoDto>(photo);

                return result ? Result<PhotoDto>.Success(photoDto) : Result<PhotoDto>.Failure("Problem adding photo");
            }
        }
    }
}