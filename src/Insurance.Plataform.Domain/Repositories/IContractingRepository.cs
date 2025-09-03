using Insurance.Plataform.Domain.Entities;

namespace Insurance.Plataform.Domain.Repositories;

public interface IContractingRepository
{
    Task<Guid> AddAsync(
        ContractingEntity contractingEntity,
        CancellationToken cancellationToken);
}
