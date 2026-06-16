using api.Services;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace api.Controllers
{
    [Route("api/cash")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private readonly CashService _cashService;

        public CashController(CashService cashService)
        {
            _cashService = cashService;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<CashSummaryDto>> GetSummary()
        {
            var summary = await _cashService.GetSummary();
            return Ok(summary);
        }

        [HttpGet("movements")]
        public async Task<ActionResult<IEnumerable<CashMovementDto>>> GetMovements()
        {
            var movements = await _cashService.GetMovements();
            return Ok(movements);
        }
    }
}
