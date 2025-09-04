using Insurance.Plataform.Application.UseCases.Contractings;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Plataform.Api.UseCases.Contractings;

[ApiController]
[Route("[controller]")]
public class ContractingsController(IContractingService contractingService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> HireProposaLAsync(
        CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await contractingService.HireProposalAsync(
                cancellationToken));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
