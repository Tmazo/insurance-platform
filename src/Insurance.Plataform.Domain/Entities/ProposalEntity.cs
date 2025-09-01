using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Domain.Entities
{
    public class ProposalEntity : BaseEntity
    {
        public required EStatus Status { get; set; }
        public required string Name { get; set; }
    }
}
