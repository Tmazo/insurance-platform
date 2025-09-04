using Insurance.Plataform.Application.UseCases.Contractings;
using Insurance.Plataform.Application.UseCases.Proposals;
using Insurance.Plataform.Domain.Repositories;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases.Proposals
{
    public class ProposalsTestBasedMock
    {
        protected readonly IProposalService proposalService;

        protected readonly IProposalRepository proposalRepository;
        protected readonly IContractingRepository contractingRepository;

        public ProposalsTestBasedMock()
        {
            proposalRepository = Substitute.For<IProposalRepository>();
            contractingRepository = Substitute.For<IContractingRepository>();

            proposalService = new ProposalService(proposalRepository);
        }
    }
}
