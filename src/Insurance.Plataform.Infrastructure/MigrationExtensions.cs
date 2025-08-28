using Insurance.Plataform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Insurance.Plataform.Infrastructure
{
    public static class MigrationExtensions
    {
        public static IHost ApplyMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<InsurancePlataformContext>();
            dbContext.Database.Migrate();

            return host;
        }
    }
}
