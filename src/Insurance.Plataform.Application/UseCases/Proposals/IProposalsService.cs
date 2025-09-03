using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Application.UseCases.Proposals;

public interface IProposalsService
{
    Task<Guid> CreateAsync(
        CreateProposalRequest createProposalRequest,
        CancellationToken cancellationToken);
    Task UpdateStatusAsync(
        Guid id,
        UpdateProposalStatusRequest updateProposalStatusRequest,
        CancellationToken cancellationToken);
    Task<IEnumerable<Proposal>> FindAllAsync(
    CancellationToken cancellationToken);

    Task<IEnumerable<Proposal>> FindByStatusAsync(
        EProposalStatus status,
        CancellationToken cancellationToken);
}
