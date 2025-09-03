using Insurance.Plataform.Application.UseCases.Proposals.Create;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Insurance.Plataform.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
        {
            builder.Services.AddServices();

            return builder;
        }

        private static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<IProposalsService, ProposalsService>();
    }
}
