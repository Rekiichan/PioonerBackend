using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend;
using Pioneer_Backend.Service;
using ZstdSharp.Unsafe;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

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
    // GET: api/Member
    [HttpGet]
    public async Task<List<Member>> Get()
    {
        return await _memberService.GetAsyncAllMember();
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
    public async Task<IActionResult> Post(Member newMember)
    {
        var isExist = await _memberService.GetAsyncMemberByName(newMember.NameID);
        if (isExist != null)
        {
            return BadRequest($"Members with NameId {newMember.NameID} Already Exists");
        }
        await _memberService.CreateAsync(newMember);
        return CreatedAtAction("GetById", new { id = newMember.MemberId }, newMember);
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