namespace Insurance.Plataform.Application.UseCases.Contractings
{
    public interface IContractingService
    {
        Task<Guid> HireProposalAsync(CancellationToken cancellationToken);
    }
}
