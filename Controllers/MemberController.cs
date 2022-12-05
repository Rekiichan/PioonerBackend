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
    public class MemberController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public MemberController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: api/Member
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _db.Members.ToListAsync();
        }

        // GET: api/Member/5
        [HttpGet("{id:int}",Name = "GetMember")]
        public async Task<ActionResult<Member>> GetMemberById(int id)
        {
            var member = await _db.Members.FindAsync(id);

            if (member == null)
            {
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
                return NotFound();
            }

            return member;
        }

        // PUT: api/Member/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.Id)
            {
                return BadRequest();
            }

            _db.Entry(member).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!MemberExists(id))
                {
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
        public async Task<IActionResult> PutMember(string nameId, Member member)
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

        // POST: api/Member
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Member>> PostMember([FromBody]Member member)
        {
            if (member == null)
            {
                return BadRequest(member);
            }
            if (member.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            member.Id = _db.Members.OrderByDescending(x => x.Id).First().Id+1;
            _db.Members.Add(member);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.Id }, member);
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
