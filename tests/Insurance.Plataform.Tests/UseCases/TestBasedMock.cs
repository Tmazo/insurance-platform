using Insurance.Plataform.Application.UseCases.Proposals;
using Insurance.Plataform.Domain.Repositories;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases
{
    public class TestBasedMock
    {
        protected readonly IProposalsService proposalsService;
        protected readonly IProposalRepository proposalRepository;

        public TestBasedMock()
        {
            proposalRepository = Substitute.For<IProposalRepository>();

            proposalsService = new ProposalsService(proposalRepository);
        }
    }
}
