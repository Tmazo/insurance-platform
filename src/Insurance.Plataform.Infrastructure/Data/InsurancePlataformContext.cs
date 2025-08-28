using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Plataform.Infrastructure.Data
{
    public class InsurancePlataformContext : DbContext
    {
        public DbSet<ProposalEntity> Proposals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProposalEntityConfiguration());
        }
    }
}
