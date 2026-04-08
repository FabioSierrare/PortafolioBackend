using Microsoft.EntityFrameworkCore;
using Portafolio.Context;
using Portafolio.Repositorie;
using Portafolio.Repositorie.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Portafolio
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDB>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuario, UsuarioRepositorie>();
            services.AddScoped<IImagen, ImagenRepositorie>();
            services.AddScoped<IProyecto, ProyectoRepositorie>();
            services.AddScoped<ITecnologia, TecnologiaRepositorie>();
            services.AddScoped<ITecnologiaProyecto, TecnologiaProyectoRepositorie>();
            services.AddScoped<ICloudy, CloudinaryRepositorie>();

            services.AddSingleton<Cloudinary>(x =>
            {
            var account = new Account(
                configuration["Cloudinary:CloudName"],
                configuration["Cloudinary:ApiKey"],
                configuration["Cloudinary:SecretKey"]
            );

                return new Cloudinary(account);
            });

            return services;
        }
    }
}
