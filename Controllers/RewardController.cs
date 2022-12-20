using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Service;
using Pioneer_Backend.Model.UpsertModel;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RewardController : ControllerBase
{
    private readonly RewardService _rewardService;
    public RewardController(RewardService context)
    {
        _rewardService = context;
    }

    [HttpGet]
    public async Task<List<Reward>> Get()
    {
        return await _rewardService.GetAsyncAllRewards();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRewardById(string id)
    {
        var reward = await _rewardService.GetAsyncRewardById(id);
        if (reward == null)
        {
            return NotFound();
        }
        return Ok(reward);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddReward(Reward newReward)
    {
        var isExist = await _rewardService.GetAsyncRewardById(newReward.RewardId);
        if (isExist != null)
        {
            return BadRequest($"Reward with Id {newReward.RewardId} Already Exists");
        }
        await _rewardService.CreateAsync(newReward);
        return CreatedAtAction("GetRewardById", new { id = newReward.RewardId }, newReward);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateReward(Reward rewardRequest, string id)
    {
        var reward = await _rewardService.GetAsyncRewardById(id);
        if (reward == null) return NotFound();
        rewardRequest.RewardId= reward.RewardId;
        await _rewardService.UpdateAsync(id, rewardRequest);
        return NoContent();
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteReward(string id)
    {
        var reward = await _rewardService.GetAsyncRewardById(id);
        if (reward == null)
        {
            return NotFound();
        }
        await _rewardService.RemoveAsync(id);
        return NoContent();
    }
}