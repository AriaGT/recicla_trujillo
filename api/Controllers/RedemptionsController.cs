using api.Services;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace api.Controllers
{
    [Route("api/redemptions")]
    [ApiController]
    public class RedemptionsController : ControllerBase
    {
        private readonly RedemptionService _redemptionService;

        public RedemptionsController(RedemptionService redemptionService)
        {
            _redemptionService = redemptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RedemptionDto>>> GetRedemptions()
        {
            var result = await _redemptionService.ListRedemptions();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RedemptionDto>> GetRedemption(int id)
        {
            var redemption = await _redemptionService.GetRedemptionById(id);

            if (redemption == null)
            {
                return NotFound();
            }

            return Ok(redemption);
        }

        [HttpPost]
        public async Task<ActionResult<RedemptionDto>> PostRedemption(RedemptionCreateDto redemptionDto)
        {
            try
            {
                var result = await _redemptionService.CreateRedemption(redemptionDto);
                return CreatedAtAction(nameof(GetRedemption), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedemption(int id)
        {
            try
            {
                var deleted = await _redemptionService.DeleteRedemption(id);
                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("validate")]
        public async Task<ActionResult<RedemptionDto>> ValidateRedemption([FromQuery] string code)
        {
            var redemption = await _redemptionService.GetRedemptionByCode(code);
            if (redemption == null)
            {
                return NotFound(new { message = "Código de canje no válido" });
            }

            return Ok(redemption);
        }
    }
}
