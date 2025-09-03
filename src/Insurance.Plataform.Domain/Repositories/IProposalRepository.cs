using Insurance.Plataform.Domain.Entities;

namespace Insurance.Plataform.Domain.Repositories;

public interface IProposalRepository
{
    Task<Guid> AddAsync(ProposalEntity proposalEntity, CancellationToken cancellationToken);
}
