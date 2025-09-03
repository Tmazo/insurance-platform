using Insurance.Plataform.Application.UseCases.Proposals;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using Insurance.Plataform.Domain.Repositories;

namespace Insurance.Plataform.Application.UseCases.Contracting
{
    public class ContractingService(
        IProposalsService proposalsService,
        IContractingRepository contractingRepository) : IContractingService
    {
        const EProposalStatus proposalStatus = EProposalStatus.Approved;

        public async Task<Guid> HireProposalAsync(CancellationToken cancellationToken)
        {
            var proposals = await proposalsService
                .FindByStatusAsync(proposalStatus, cancellationToken);

            if (!proposals.Any())
                throw new Exception();//TODO: ajustar erro. 

            var useProposal = proposals.FirstOrDefault();

            var result = await contractingRepository.AddAsync(
                contractingEntity: new ContractingEntity()
                {
                    ProposalId = useProposal.Id,
                    Date = DateTime.Now
                },
                cancellationToken: cancellationToken);

            return result;
        }
    }
}
