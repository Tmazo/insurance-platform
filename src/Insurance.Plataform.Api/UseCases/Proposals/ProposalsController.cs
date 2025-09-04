using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Application.UseCases.Proposals;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Plataform.Api.UseCases.Proposals;

[ApiController]
[Route("[controller]")]
public class ProposalsController(IProposalService proposalsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateProposalRequest createProposalRequest,
        CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await proposalsService.CreateAsync(
                createProposalRequest,
                cancellationToken));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(
        CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await proposalsService
                .FindAllAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

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
