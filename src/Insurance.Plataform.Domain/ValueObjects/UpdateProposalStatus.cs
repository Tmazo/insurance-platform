using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Domain.ValueObjects;

public record UpdateProposalStatus(Guid Id, EProposalStatus Status);
