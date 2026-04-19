using api.Services;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace api.Controllers
{
    [Route("api/deliveries")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliveryService _deliveryService;

        public DeliveriesController(DeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryDto>>> GetDeliveries()
        {
            var result = await _deliveryService.ListDeliveries();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryDto>> GetDelivery(int id)
        {
            var delivery = await _deliveryService.GetDeliveryById(id);
            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, DeliveryUpdateDto deliveryDto)
        {
            try
            {
                var updated = await _deliveryService.UpdateDelivery(id, deliveryDto);
                if (updated == null)
                    return NotFound();
                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<DeliveryDto>> Create(DeliveryCreateDto deliveryDto)
        {
            try
            {
                var result = await _deliveryService.RegisterDelivery(deliveryDto);
                return CreatedAtAction(nameof(GetDelivery), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var deleted = await _deliveryService.DeleteDelivery(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
