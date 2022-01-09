using System.Threading.Tasks;
using Application.Photos;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotosUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}