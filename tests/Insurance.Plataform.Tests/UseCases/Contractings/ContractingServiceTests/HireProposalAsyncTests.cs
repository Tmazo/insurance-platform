using FluentAssertions;
using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Application.Exceptions;
using Insurance.Plataform.Application.UseCases.Contractings;
using Insurance.Plataform.Application.UseCases.Proposals;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using Insurance.Plataform.Domain.Repositories;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases.Contractings.ContractingServiceTests;

public class HireProposalAsyncTests
{
    protected readonly IProposalService proposalService;
    protected readonly IContractingService contractingService;

    protected readonly IContractingRepository contractingRepository;

    public HireProposalAsyncTests()
    {
        proposalService = Substitute.For<IProposalService>();
        contractingRepository = Substitute.For<IContractingRepository>();

        contractingService = new ContractingService(proposalService, contractingRepository);
    }

    [Fact]
    public async Task HireProposal_Should_Success_Return_Id()
    {
        //Arrange
        var returnProposals = new List<Proposal>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Status = EProposalStatus.Approved
            }
        };

        contractingRepository
            .AddAsync(Arg.Any<ContractingEntity>(), CancellationToken.None)
            .Returns(Guid.NewGuid());

        proposalService
            .FindByStatusAsync(EProposalStatus.Approved, CancellationToken.None)
            .Returns(returnProposals);

        //Act
        var result = await contractingService.HireProposalAsync(CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
    }

    [Fact]
    public async Task HireProposalUpdateStatus_Throw_ProposalNotFoundException_When_Proposal_NotFound()
    {
        // Act
        Func<Task> act = async () =>
        await contractingService.HireProposalAsync(CancellationToken.None);

        // Assert
        await act
            .Should()
            .ThrowAsync<ProposalNotFoundException>()
            .WithMessage($"No proposal was found.");
    }
}
