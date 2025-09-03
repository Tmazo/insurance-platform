using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Application.UseCases.Proposals.Create;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Plataform.Api.UseCases.Proposals.Patch;

[ApiController]
[Route("[controller]")]
public class ProposalsController(IProposalsService proposalsService) : ControllerBase
{
    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatusAsync(
        Guid id,
        [FromBody] UpdateProposalStatusRequest updateProposalStatusRequest,
        CancellationToken cancellationToken)
    {
        try
        {
            await proposalsService.UpdateStatusAsync(
                id,
                updateProposalStatusRequest,
                cancellationToken);

            return NoContent();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
