using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using shared;

namespace api.Controllers
{
    [Route("api/rewards")]
    [ApiController]
    public class RewardsController : ControllerBase
    {
        private readonly RewardsService _rewardsService;

        public RewardsController(RewardsService rewardsService)
        {
            _rewardsService = rewardsService;
        }

        // GET: api/rewards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RewardDto>>> GetRewards()
        {
            var result = await _rewardsService.ListRewards();
            return Ok(result);
        }

        // GET: api/rewards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RewardDto>> GetReward(int id)
        {
            var reward = await _rewardsService.GetRewardById(id);

            if (reward == null)
            {
                return NotFound();
            }

            return Ok(reward);
        }

        // PUT: api/rewards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReward(int id, RewardUpdateDto rewardDto)
        {
            try
            {
                var updated = await _rewardsService.UpdateReward(id, rewardDto);
                if (updated == null)
                {
                    return NotFound();
                }

                return Ok(updated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/rewards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RewardDto>> PostReward(RewardCreateDto rewardDto)
        {
            try
            {
                var result = await _rewardsService.CreateReward(rewardDto);
                return CreatedAtAction(nameof(GetReward), new { id = result.Id }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/rewards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReward(int id)
        {
            var deleted = await _rewardsService.DeleteReward(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
