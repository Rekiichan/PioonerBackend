using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Service;
using Pioneer_Backend.Model;
using Pioneer_Backend.Model.UpsertModel;

namespace Pioneer_Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly MemberService _memberService;
    public MemberController(MemberService context)
    {
        _memberService = context;
    }

    [HttpGet]
    public async Task<List<Member>> Get()
    {
        return await _memberService.GetAsyncAllMembers();
    }

    [HttpGet("{nameId}")]
    public async Task<IActionResult> GetByNameId(string nameId)
    {
        var member = await _memberService.GetAsyncMemberByName(nameId);
        if (member == null)
        {
            return NotFound();
        }
        return Ok(member);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var member = await _memberService.GetAsyncMemberById(id);
        if (member == null)
        {
            return NotFound();
        }
        return Ok(member);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(MemberUpsert newMember)
    {
        var member = new Member()
        {
            NameID = newMember.NameID,
            Name = newMember.Name,
            Mssv = newMember.Mssv,
            Role = newMember.Role,
            Position = newMember.Position,
            ImageUrl = newMember.ImageUrl,
            Strenghs = newMember.Strenghs,
            Term = newMember.Term,
            Class = newMember.Class,
            Facebook = newMember.Facebook,
            Gmail = newMember.Gmail,
            GitHub = newMember.GitHub,
            Linkedin = newMember.Linkedin,
            CV = newMember.CV,
            Description = newMember.Description,
        };
        await _memberService.CreateAsync(member);
        return CreatedAtAction("GetById", new { id = member.MemberId }, member);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateMember(Member memberRequest, string id)
    {
        var member = await _memberService.GetAsyncMemberById(id);
        if (member == null) return NotFound();

        memberRequest.MemberId = member.MemberId;
        await _memberService.UpdateAsync(id, memberRequest);
        return NoContent();
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteMember(string id)
    {
        var member = await _memberService.GetAsyncMemberById(id);
        if (member == null)
        {
            return NotFound();
        }
        await _memberService.RemoveAsync(id);
        return NoContent();
    }
}