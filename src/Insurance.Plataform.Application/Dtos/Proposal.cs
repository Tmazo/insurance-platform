using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Application.Dtos;

public class Proposal
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required EProposalStatus Status { get; set; }
}
