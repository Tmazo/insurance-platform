using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Repositories;
using Insurance.Plataform.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Plataform.Infrastructure.Repositories;

public class ContractingRepository(InsurancePlataformContext dbContext) : IContractingRepository
{
    readonly DbSet<ContractingEntity> _contractingContext = dbContext.Set<ContractingEntity>();

    public async Task<Guid> AddAsync(
        ContractingEntity contractingEntity,
        CancellationToken cancellationToken)
    {
        await _contractingContext.AddAsync(contractingEntity, cancellationToken);

        return contractingEntity.Id;
    }
}
