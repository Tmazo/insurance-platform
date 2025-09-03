using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Repositories;
using Insurance.Plataform.Infrastructure.Data;

namespace Insurance.Plataform.Infrastructure.Repositories;

public class ProposalRepository(InsurancePlataformContext dbContext) : IProposalRepository
{
    public async Task<Guid> AddAsync(ProposalEntity proposalEntity, CancellationToken cancellationToken)
    {
        await dbContext.Set<ProposalEntity>().AddAsync(proposalEntity, cancellationToken);
        return proposalEntity.Id;
    }

}
