namespace Insurance.Plataform.Application.Exceptions;

public class ProposalNotFoundByIdException(Guid id) : Exception($"Proposal with Id {id} was not found.");