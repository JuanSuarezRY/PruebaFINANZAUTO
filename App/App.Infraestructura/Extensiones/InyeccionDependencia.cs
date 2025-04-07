using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Infraestructura.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infraestructura.Extensiones
{
    public static class InyeccionDependencia
    {
        public static IServiceCollection AddInfrastructura(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DbAppContext).Assembly.FullName;

            services.AddDbContext<DbAppContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("SqlServer")));

            return services;
        }
    }
}
