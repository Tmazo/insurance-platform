using Insurance.Plataform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurance.Plataform.Infrastructure.Data.Configurations;

public class ContractingEntityConfiguration : IEntityTypeConfiguration<ContractingEntity>
{
    public void Configure(EntityTypeBuilder<ContractingEntity> builder)
    {
        builder.ToTable("Contractings");
    }
}
