using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Plataform.Infrastructure.Data;

public class InsurancePlataformContext : DbContext
{
    public DbSet<ProposalEntity> Proposals { get; set; }
    public DbSet<ContractingEntity> Contractings { get; set; }

    public InsurancePlataformContext(DbContextOptions<InsurancePlataformContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ProposalEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ContractingEntityConfiguration()); 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
