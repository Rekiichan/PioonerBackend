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

    [HttpGet("{NameId}")]
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
    public async Task<IActionResult> AddReward(RewardUpsert newReward)
    {
        var obj = new Reward()
        {
            MemberName= newReward.MemberName,
            RewardRank=newReward.RewardRank,
            ContestName=newReward.ContestName,
            ImageUrl = newReward.ImageUrl,
            Description = newReward.Description,
        };
        await _rewardService.CreateAsync(obj);
        return CreatedAtAction("GetRewardById", new { id = obj.RewardId }, obj);
    }

    [HttpPut("{NameId}")]
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
    [HttpDelete("{NameId}")]
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