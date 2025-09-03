using Insurance.Plataform.Domain.Repositories;
using Insurance.Plataform.Infrastructure.Data;
using Insurance.Plataform.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Insurance.Plataform.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IHostApplicationBuilder AddInfra(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<InsurancePlataformContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IProposalRepository, ProposalRepository>();

        return builder;
    }

}
