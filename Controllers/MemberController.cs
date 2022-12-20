using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Service;
using Pioneer_Backend.Model;
using Pioneer_Backend.Model.UpsertModel;
using Pioneer_Backend.PreProccessData;
using MongoDB.Bson;

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
        Console.WriteLine("get all");
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(MemberUpsert newMember)
    {
        var nameId = NameIdConvert.NameToNameId(newMember.Name);
        var isExist = _memberService.GetMemberSyncByName(nameId);
        if (isExist != null)
        {
            return BadRequest($"{newMember.Name} is Already Exist!!!");
        }
        var member = new Member()
        {
            NameId = nameId,
            Name = newMember.Name,
            Mssv = newMember.Mssv,
            Role = newMember.Role,
            Position = newMember.Position,
            ImageUrl = newMember.ImageUrl,
            Strenghs = newMember.Strenghs,
            Term = newMember.Term,
            Class = newMember.Class,
            Contact = newMember.Contact,
            Description = newMember.Description,
        };
        await _memberService.CreateAsync(member);
        return CreatedAtAction("GetByNameId", new { nameId = member.NameId }, member);
    }

    [HttpPut("{NameId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateMember(MemberUpsert memberRequest, string id)
    {
        var member = await _memberService.GetAsyncMemberById(id);
        if (member == null)
        {
            return NotFound();
        }
        if (member.Name == memberRequest.Name)
        {

        }
        var obj = new Member()
        {
            MemberId = id,
            NameId = (member.Name == memberRequest.Name) ? member.NameId : NameIdConvert.NameToNameId(memberRequest.Name),
            Name = memberRequest.Name,
            Mssv = memberRequest.Mssv,
            Role = memberRequest.Role,
            Position = memberRequest.Position,
            ImageUrl = memberRequest.ImageUrl,
            Strenghs = memberRequest.Strenghs,
            Term = memberRequest.Term,
            Class = memberRequest.Class,
            Contact = memberRequest.Contact,
            Description = memberRequest.Description
        };
        await _memberService.UpdateAsync(id, obj);
        return NoContent();
    }
    [HttpDelete("{NameId}")]
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