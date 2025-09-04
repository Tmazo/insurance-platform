using FluentAssertions;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases.Proposals.ProposalsServiceTests;

public class FindAllAsyncTests : ProposalsTestBasedMock
{
    [Fact]
    public async Task FindAll_Should_Success_Return_ProposalEntities()
    {
        //Arrange
        var returnProposals = new List<ProposalEntity>()
        {
            new()
            {
                Name = "Test",
                Status = EProposalStatus.Approved
            }
        };

        proposalRepository
            .FindAllAsync(CancellationToken.None)
            .Returns(returnProposals);

        //Act
        var result = await proposalService.FindAllAsync(CancellationToken.None);

        //Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.FirstOrDefault()?.Id.Should().Be(returnProposals.FirstOrDefault()!.Id);
    }
}
