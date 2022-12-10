using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend;

namespace Pioneer_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IDynamoDBContext _context;
    public MemberController(IDynamoDBContext context)
    {
        _context = context;
    }
    // GET: api/Member
    [HttpGet]
    public async Task<IActionResult> GetAllmembers()
    {
        var MemberList = await _context.ScanAsync<Member>(default).GetRemainingAsync();
        return Ok(MemberList);
    }
    [HttpGet("{nameId}")]
    public async Task<IActionResult> GetByNameId(string nameId)
    {
        var member = await _context.LoadAsync<Member>(nameId);
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
    public async Task<IActionResult> CreateMember(Member memberRequest)
    {
        var member = await _context.LoadAsync<Member>(memberRequest.NameID);

        if (member != null) return BadRequest($"Members with Id {memberRequest.NameID} Already Exists");
        await _context.SaveAsync(memberRequest);
        return Ok(memberRequest);
    }

    [HttpDelete("{nameId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteMember(string nameId)
    {
        var member = await _context.LoadAsync<Member>(nameId);
        if (member == null) return NotFound();
        await _context.DeleteAsync(member);
        return NoContent();
    }
    [HttpPut("{nameId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateMember(Member memberRequest, string nameId)
    {
        var member = await _context.LoadAsync<Member>(nameId);
        if (member == null) return NotFound();
        await _context.SaveAsync(memberRequest);
        return Ok(memberRequest);
    }
}