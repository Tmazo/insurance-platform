using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using Insurance.Plataform.Domain.Repositories;
using Insurance.Plataform.Domain.ValueObjects;
using Insurance.Plataform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Plataform.Infrastructure.Repositories;

public class ProposalRepository(InsurancePlataformContext dbContext) : IProposalRepository
{
    readonly DbSet<ProposalEntity> _proposalsContext = dbContext.Set<ProposalEntity>();

    public async Task<Guid> AddAsync(
        ProposalEntity proposalEntity,
        CancellationToken cancellationToken)
    {
        await _proposalsContext.AddAsync(proposalEntity, cancellationToken);
        return proposalEntity.Id;
    }

    public async Task UpdateStatusAsync(
        UpdateProposalStatus updateProposalStatus,
        CancellationToken cancellationToken)
    {
        var proposal = await _proposalsContext
            .FirstOrDefaultAsync(f => f.Id == updateProposalStatus.Id, cancellationToken)
            ?? throw new Exception(); //TODO: ajustar erro

        proposal.Status = updateProposalStatus.Status;

        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProposalEntity>> FindAllAsync(
        CancellationToken cancellationToken) =>
        await _proposalsContext.ToListAsync(cancellationToken);

    public async Task<IEnumerable<ProposalEntity>> FindByStatusAsync(
        EProposalStatus status,
        CancellationToken cancellationToken) =>
        await _proposalsContext.Where(w => w.Status == status)
        .ToListAsync(cancellationToken);
}
