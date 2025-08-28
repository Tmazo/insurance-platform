using Insurance.Plataform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Runtime.CompilerServices;

namespace Insurance.Plataform.Infrastructure
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            services.AddDbContext<InsurancePlataformContext>(options =>
                options.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;"));

            return services;
        }

    }
}
