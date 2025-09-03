using Insurance.Plataform.Application.Dtos;

namespace Insurance.Plataform.Application.UseCases.Proposals.Create;

public interface IProposalsService
{
    Task<Guid> CreateAsync(
        CreateProposalRequest createProposalRequest,
        CancellationToken cancellationToken);
    Task UpdateStatusAsync(
        Guid id,
        UpdateProposalStatusRequest updateProposalStatusRequest,
        CancellationToken cancellationToken);
    Task<IEnumerable<ProposalResponse>> FindAllAsync(
    CancellationToken cancellationToken);
}
