using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Domain.Repositories;

public interface IProposalRepository
{
    Task<Guid> AddAsync(
        ProposalEntity proposalEntity,
        CancellationToken cancellationToken);
    Task SaveChangesAsync(
            CancellationToken cancellationToken);
    Task<IEnumerable<ProposalEntity>> FindAllAsync(
        CancellationToken cancellationToken);

    Task<IEnumerable<ProposalEntity>> FindByStatusAsync(
        EProposalStatus status,
        CancellationToken cancellationToken);

    Task<ProposalEntity?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken);
}
