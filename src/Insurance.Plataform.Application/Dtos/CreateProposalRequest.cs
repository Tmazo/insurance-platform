using Insurance.Plataform.Domain.Enums;

namespace Insurance.Plataform.Application.Dtos;

public record CreateProposalRequest(string Name, EProposalStatus Status);
