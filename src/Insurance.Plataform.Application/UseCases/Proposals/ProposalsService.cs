using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using Insurance.Plataform.Domain.Repositories;
using Insurance.Plataform.Domain.ValueObjects;

namespace Insurance.Plataform.Application.UseCases.Proposals;

public class ProposalsService(IProposalRepository proposalRepository) : IProposalsService
{
    public async Task<Guid> CreateAsync(
        CreateProposalRequest createProposalRequest,
        CancellationToken cancellationToken) =>
        await proposalRepository.AddAsync(
            proposalEntity: new ProposalEntity()
            {
                Name = createProposalRequest.Name,
                Status = createProposalRequest.Status
            },
            cancellationToken: cancellationToken);

    public async Task UpdateStatusAsync(
        Guid id,
        UpdateProposalStatusRequest updateProposalStatusRequest,
        CancellationToken cancellationToken) =>
        await proposalRepository.UpdateStatusAsync(
            new UpdateProposalStatus(id, updateProposalStatusRequest.Status),
            cancellationToken);

    public async Task<IEnumerable<Proposal>> FindAllAsync(CancellationToken cancellationToken)
    {
        var proposals = await proposalRepository
            .FindAllAsync(cancellationToken);

        return proposals.Select(p => new Proposal
        {
            Id = p.Id,
            Name = p.Name,
            Status = p.Status
        });
    }

    public async Task<IEnumerable<Proposal>> FindByStatusAsync(
        EProposalStatus status,
        CancellationToken cancellationToken)
    {
        var proposals = await proposalRepository
            .FindByStatusAsync(status, cancellationToken);

        return proposals.Select(p => new Proposal
        {
            Id = p.Id,
            Name = p.Name,
            Status = p.Status
        });
    }
}
