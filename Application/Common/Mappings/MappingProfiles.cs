using System.Linq;
using Application.Categories.DTOs;
using Application.Common.DTOs;
using Application.Photos.DTOs;
using Application.Products.DTOs;
using Application.Types.DTOs;
using AutoMapper;
using Domain;

namespace Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, Product>();
            CreateMap<Type, Type>();
            CreateMap<Category, Category>();
            /*CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl,
                    opt => opt.MapFrom(src =>
                        src.Photos.FirstOrDefault(x => x.IsMain).Url));*/
            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<MemberUpdateDto, AppUser>();

            CreateMap<Product, ProductDto>().ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src =>
                    src.Photos.FirstOrDefault(x => x.IsMain).Url));
            ;
            CreateMap<ProductCreatedDto, Product>().ReverseMap();
            CreateMap<Product, ProductPatchDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreatedDto, Category>().ReverseMap();
            CreateMap<Type, TypeDto>();
            CreateMap<TypeCreateDto, Type>().ReverseMap();
        }
    }
}