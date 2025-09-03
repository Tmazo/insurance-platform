using Insurance.Plataform.Application.Dtos;
using Insurance.Plataform.Application.UseCases.Proposals.Create;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Plataform.Api.UseCases.Proposals.Create;

[ApiController]
[Route("[controller]")]
public class ProposalsController(IProposalsService proposalsService) : ControllerBase
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
}
