using Microsoft.EntityFrameworkCore;
using Portafolio.Context;
using Portafolio.Repositorie;
using Portafolio.Repositorie.Interfaces;

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

            return services;
        }
    }
}
