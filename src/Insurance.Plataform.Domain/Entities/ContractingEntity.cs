using System;

namespace Insurance.Plataform.Domain.Entities
{
    public class ContractingEntity : BaseEntity
    {
        public required string Name { get; set; }
        public required Guid ProposalId { get; set; }
        public required DateTime Date { get; set; }

        public ProposalEntity Proposal { get; set; }
    }
}
