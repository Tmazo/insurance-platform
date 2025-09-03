using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Repositories;

namespace Insurance.Plataform.Application.UseCases.Proposals.Create;

public class ProposalsService(IProposalRepository proposalRepository) : IProposalsService
{
    public async Task<Guid> CreateAsync(CreateProposalRequest createProposalRequest, CancellationToken cancellationToken) =>
        await proposalRepository.AddAsync(
            proposalEntity: new ProposalEntity()
            {
                Name = createProposalRequest.Name,
                Status = createProposalRequest.Status
            },
            cancellationToken: cancellationToken);
}
