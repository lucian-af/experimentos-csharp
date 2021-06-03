using LOG.API.Dados;
using LOG.API.Interfaces;
using LOG.API.Repositories;
using LOG.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LOG.API.Start
{
    public static class InjecaoDependencia
    {
        public static void InjetarDependencias(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<Context>(d => d.UseSqlServer(Configuration.GetConnectionString("connection")));
            services.AddScoped<DbContext, Context>();

            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioGenerico<>));

            services.AddScoped<ServicoLog>();
        }
    }
}
