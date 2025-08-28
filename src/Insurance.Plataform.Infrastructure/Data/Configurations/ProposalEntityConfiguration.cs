using Insurance.Plataform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Plataform.Infrastructure.Data.Configurations
{
    public class ProposalEntityConfiguration : IEntityTypeConfiguration<ProposalEntity>
    {
        public void Configure(EntityTypeBuilder<ProposalEntity> builder)
        {
            builder.ToTable("Proposals");
        }
    }
}
