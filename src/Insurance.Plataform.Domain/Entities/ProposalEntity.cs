using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Domain.Entities;

public class ProposalEntity : BaseEntity
{
    public required string Name { get; set; }
    public required EProposalStatus Status { get; set; }

    public IEnumerable<ContractingEntity> Contractings { get; set; }
}
