using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Users;
using Infrastructure.MercadoPago;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using Persistence.ProductRepository;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo() {Title = "API", Version = "v1"}); });

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy",
                    policy =>
                    {
                        policy
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
                            .WithOrigins("http://localhost:4200", "http://localhost:8080", "http://localhost:8081");
                    });
            });
            /**/
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddScoped<IMercadoPagoAccessor, MercadoPagoAccessor>();
            services.Configure<MercadoPagoSettings>(configuration.GetSection("MercadoPago"));

            /*********** Start - Repositories ***********/
            services.AddScoped<IProductRepository, ProductRepository>();
            /*********** End - Repositories ***********/
            /*
          
           services.AddScoped<IPhotoAccessor, PhotoAccessor>();
           services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
           services.AddSignalR();
           */

            return services;
        }
    }
}