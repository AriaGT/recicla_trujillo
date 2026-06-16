using api.Services;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace api.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _saleService;

        public SalesController(SaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleDto>>> GetSales([FromQuery] int? userId)
        {
            var result = await _saleService.ListSales(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleDto>> GetSale(int id)
        {
            var sale = await _saleService.GetSaleById(id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        [HttpPost]
        public async Task<ActionResult<SaleDto>> PostSale(SaleCreateDto saleDto)
        {
            try
            {
                var result = await _saleService.CreateSale(saleDto);
                return CreatedAtAction(nameof(GetSale), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            try
            {
                var deleted = await _saleService.DeleteSale(id);
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
        public async Task<ActionResult<SaleDto>> ValidateSale([FromQuery] string code)
        {
            var sale = await _saleService.GetSaleByCode(code);
            if (sale == null)
            {
                return NotFound(new { message = "Código de venta no válido" });
            }

            return Ok(sale);
        }
    }
}
