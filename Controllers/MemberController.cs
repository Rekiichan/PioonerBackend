using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pioneer_Backend.DataAccess.Data;
using Pioneer_Backend.Model;
using static Azure.Core.HttpHeader;

namespace Pioneer_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<MemberController> _logger;
        public MemberController(ApplicationDbContext context,ILogger<MemberController> logger)
        {
            _db = context;
            _logger = logger;
        }

        // GET: api/Member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            _logger.LogInformation("LOG: Getting all members");
            return await _db.Members.ToListAsync();
        }

        // GET: api/Member/5
        [HttpGet("{id:int}", Name = "GetMemberById")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            if (id == 0)
            {
                _logger.LogInformation("LOG: Get member error with Id " + id);
                return BadRequest();
            }
            var member = await _db.Members.FindAsync(id);
            if (member == null)
            {
                _logger.LogInformation("LOG: Don't see member data with Id " + id);
                return NotFound();
            }

            return member;
        }

        [HttpGet("{nameId}")]
        public async Task<ActionResult<Member>> GetMemberByNameId(string nameId)
        {

            var member = await _db.Members.FirstOrDefaultAsync(x => x.NameID == nameId);
            if (member == null)
            {
                _logger.LogInformation("LOG: Don't see member data with nameId " + nameId);
                return NotFound();
            }

            return member;
        }

        // POST: api/Member
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Member>> PostMember([FromForm] Member member)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (_db.Members.FirstOrDefault(u => u.Name.ToLower() == member.Name.ToLower()) != null)
            {
                _logger.LogInformation("LOG: This member already exist!!!");
                ModelState.AddModelError("CustomError", "Member already Exists!");
                return BadRequest(ModelState);
            }
            if (member == null)
            {
                _logger.LogInformation("LOG: member is null!!!");
                return BadRequest(member);
            }
            if (member.Id > 0)
            {
                _logger.LogInformation("LOG: Id Init is not zero!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            _db.Members.Add(member);
            await _db.SaveChangesAsync();
            _logger.LogInformation("LOG: Add member Success!!!");
            return CreatedAtAction("GetMemberById", new { id = member.Id }, member);
        }

        // PUT: api/Member/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutMember(int id, [FromBody] Member member)
        {
            if (id != member.Id)
            {
                _logger.LogInformation("LOG: Don't see member with id: !!!" + id);
                return BadRequest();
            }

            _db.Entry(member).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
                _logger.LogInformation("LOG: Update Success!!!");
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!MemberExists(id))
                {
                    _logger.LogInformation("LOG: This member already exist!!!");
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }

            return NoContent();
        }

        [HttpPut("{nameId}")]
        public async Task<IActionResult> PutMember(string nameId, [FromBody] Member member)
        {
            if (nameId != member.NameID)
            {
                return BadRequest();
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!MemberExists(nameId))
                {
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }
            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Member/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _db.Members.Remove(member);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberExists(int id)
        {
            return _db.Members.Any(e => e.Id == id);
        }
        private bool MemberExists(string nameId)
        {
            return _db.Members.Any(e => e.NameID == nameId);
        }
    }
}
