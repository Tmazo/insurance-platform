using FluentAssertions;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases.Proposals.ProposalsServiceTests;

public class FindByStatusAsyncTests : ProposalsTestBasedMock
{
    [Fact]
    public async Task FindByStatus_Should_Success_Return_ProposalEntities()
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
            .FindByStatusAsync(EProposalStatus.Approved, CancellationToken.None)
            .Returns(returnProposals);

        //Act
        var result = await proposalService.FindByStatusAsync(EProposalStatus.Approved, CancellationToken.None);

        //Assert
        result.Should().NotBeNull();
        result.Should().NotBeEmpty();
        result.FirstOrDefault()?.Id.Should().Be(returnProposals.FirstOrDefault()!.Id);
    }
}
