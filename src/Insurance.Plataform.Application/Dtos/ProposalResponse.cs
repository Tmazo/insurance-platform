using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Application.Dtos;

public class ProposalResponse
{
    public required string Name { get; set; }
    public required EProposalStatus Status { get; set; }
}
