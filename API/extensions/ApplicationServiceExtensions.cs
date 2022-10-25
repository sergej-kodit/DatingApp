using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Helpers;
using API.interfaces;
using API.Services;
using API.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<PresenceTracker>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<LogUserActivity>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(option =>
            {
                option.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });


            return services;
        }
    }
}