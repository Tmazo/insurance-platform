using FluentAssertions;
using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Application.Exceptions;
using Insurance.Plataform.Domain.Entities;
using Insurance.Plataform.Domain.Enums;
using NSubstitute;

namespace Insurance.Plataform.Tests.UseCases.Proposals.ProposalsServiceTests;

public class UpdateStatusAsyncTests : ProposalsTestBasedMock
{
    [Fact]
    public async Task UpdateStatus_Should_Success()
    {
        //Arrange
        var updateProposalStatusRequest = new UpdateProposalStatusRequest(EProposalStatus.UnderReview);
        var id = Guid.NewGuid();

        proposalRepository
            .FindByIdAsync(
            Arg.Any<Guid>(), 
            Arg.Any<CancellationToken>())
            .Returns(
            new ProposalEntity() 
            { 
                Id = id,
                Name  = "Test",
                Status = EProposalStatus.Approved
            });

        //Act
        await proposalService.UpdateStatusAsync(id, updateProposalStatusRequest, CancellationToken.None);
    }

    [Fact]
    public async Task UpdateStatus_Throw_ProposalNotFoundByIdException_When_Proposal_NotFound()
    {
        //Arrange
        var updateProposalStatusRequest = new UpdateProposalStatusRequest(EProposalStatus.UnderReview);
        var id = Guid.NewGuid();

        // Act
        Func<Task> act = async () => 
        await proposalService
        .UpdateStatusAsync(
            id,
            updateProposalStatusRequest,
            CancellationToken.None);

        // Assert
        await act
            .Should()
            .ThrowAsync<ProposalNotFoundByIdException>()
            .WithMessage($"Proposal with Id {id} was not found.");
    }
}
