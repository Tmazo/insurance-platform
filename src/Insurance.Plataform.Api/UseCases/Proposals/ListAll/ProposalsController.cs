using Insurance.Plataform.Application.UseCases.Proposals.Create;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Plataform.Api.UseCases.Proposals.ListAll;

[ApiController]
[Route("[controller]")]
public class ProposalsController(IProposalsService proposalsService) : ControllerBase
{
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
}
