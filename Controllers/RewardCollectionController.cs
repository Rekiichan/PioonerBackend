using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pioneer_Backend.DataAccess.Data;
using Pioneer_Backend.Model;

namespace Pioneer_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardCollectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RewardCollectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RewardCollection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RewardCollection>>> GetRewards()
        {
            return await _context.Rewards.ToListAsync();
        }

        // GET: api/RewardCollection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RewardCollection>> GetRewardCollection(int id)
        {
            var rewardCollection = await _context.Rewards.FindAsync(id);

            if (rewardCollection == null)
            {
                return NotFound();
            }

            return rewardCollection;
        }

        // PUT: api/RewardCollection/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRewardCollection(int id, RewardCollection rewardCollection)
        {
            if (id != rewardCollection.Id)
            {
                return BadRequest();
            }

            _context.Entry(rewardCollection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RewardCollectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RewardCollection
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RewardCollection>> PostRewardCollection(RewardCollection rewardCollection)
        {
            _context.Rewards.Add(rewardCollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRewardCollection", new { id = rewardCollection.Id }, rewardCollection);
        }

        // DELETE: api/RewardCollection/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRewardCollection(int id)
        {
            var rewardCollection = await _context.Rewards.FindAsync(id);
            if (rewardCollection == null)
            {
                return NotFound();
            }

            _context.Rewards.Remove(rewardCollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RewardCollectionExists(int id)
        {
            return _context.Rewards.Any(e => e.Id == id);
        }
    }
}
