using FluentAssertions;
using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases.Proposals.ProposalsService;

public class CreateAsyncTests : TestBasedMock
{
    [Fact]
    public async Task Create_Should_Success_Return_Id()
    {
        //Arrange
        var createProposalRequest = new CreateProposalRequest("Test", EProposalStatus.Approved);
        proposalRepository.AddAsync(Arg.Any<ProposalEntity>(), Arg.Any<CancellationToken>()).Returns(Guid.NewGuid());

        //Act
        var result = await proposalsService.CreateAsync(createProposalRequest, CancellationToken.None);

        //Assert
        result.Should().NotBeEmpty();
    }
}
