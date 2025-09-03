using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using Insurance.Plataform.Domain.Repositories;
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

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken) =>
        await dbContext.SaveChangesAsync(cancellationToken);

    public async Task<ProposalEntity?> FindByIdAsync(
        Guid id,
        CancellationToken cancellationToken) =>
        await _proposalsContext
        .AsTracking()
        .FirstOrDefaultAsync(w => w.Id == id);

    public async Task<IEnumerable<ProposalEntity>> FindAllAsync(
        CancellationToken cancellationToken) =>
        await _proposalsContext.ToListAsync(cancellationToken);

    public async Task<IEnumerable<ProposalEntity>> FindByStatusAsync(
        EProposalStatus status,
        CancellationToken cancellationToken) =>
        await _proposalsContext.Where(w => w.Status == status)
        .ToListAsync(cancellationToken);
}
