using Microsoft.AspNetCore.Mvc;

namespace Insurance.Plataform.Api.UseCases.Proposals.Create
{
    [ApiController]
    [Route("[controller]")]
    public class ProposalsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Create()
        {
            return NoContent();
        }
    }
}
