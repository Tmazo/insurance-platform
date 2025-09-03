namespace Insurance.Plataform.Application.UseCases.Contracting
{
    public interface IContractingService
    {
        Task<Guid> HireProposalAsync(CancellationToken cancellationToken);
    }
}
