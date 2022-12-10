using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RewardListController : ControllerBase
{
    private readonly IDynamoDBContext _context;

    public RewardListController(IDynamoDBContext context)
    {
        _context = context;
    }

    // GET: api/RewardCollection
    [HttpGet]
    public async Task<IActionResult> GetAllRewardList()
    {
        var RewardList = await _context.ScanAsync<RewardList>(default).GetRemainingAsync();
        return Ok(RewardList);
    }
    // GET: api/RewardCollection/5
    [HttpGet("{rewardId}")]
    public async Task<ActionResult<RewardList>> GetRewardrewardById(string rewardId)
    {
        var reward = await _context.LoadAsync<RewardList>(rewardId);

        if (reward == null)
        {
            return NotFound();
        }
        return Ok(reward);
    }

    // PUT: api/RewardCollection/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut]
    public async Task<IActionResult> UpdateReward(string rewardId, RewardList rewardRequest)
    {
        var reward = await _context.LoadAsync<RewardList>(rewardRequest.RewardId);
        if (reward == null) return NotFound();
        await _context.SaveAsync(rewardRequest);
        return Ok(rewardRequest);
    }

    // POST: api/RewardCollection
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RewardList>> AddReward(RewardList rewardRequest)
    {
        var reward = await _context.LoadAsync<RewardList>(rewardRequest.RewardId);

        if (reward != null) return BadRequest($"Reward with Id {rewardRequest.RewardId} Already Exists");
        await _context.SaveAsync(rewardRequest);
        return Ok(rewardRequest);
    }

    // DELETE: api/RewardCollection/5
    [HttpDelete("{rewardId}")]
    public async Task<IActionResult> DeleteRewardById(string rewardId)
    {
        var reward = await _context.LoadAsync<RewardList>(rewardId);
        if (reward == null) return NotFound();
        await _context.DeleteAsync(reward);
        return NoContent();
    }
}
