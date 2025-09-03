using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using Insurance.Plataform.Domain.ValueObjects;

namespace Insurance.Plataform.Domain.Repositories;

public interface IProposalRepository
{
    Task<Guid> AddAsync(
        ProposalEntity proposalEntity,
        CancellationToken cancellationToken);
    Task UpdateStatusAsync(
        UpdateProposalStatus updateProposalStatus,
        CancellationToken cancellationToken);
    Task<IEnumerable<ProposalEntity>> FindAllAsync(
        CancellationToken cancellationToken);

    Task<IEnumerable<ProposalEntity>> FindByStatusAsync(
        EProposalStatus status,
        CancellationToken cancellationToken);
}
