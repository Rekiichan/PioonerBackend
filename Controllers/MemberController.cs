using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend;

namespace DynamoStudentManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IDynamoDBContext _context;
    public MemberController(IDynamoDBContext context)
    {
        _context = context;
    }
    [HttpGet("{memberId}")]
    public async Task<IActionResult> GetById(int memberId)
    {
        var member = await _context.LoadAsync<Member>(memberId);
        if (member == null) return NotFound();
        return Ok(member);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllmembers()
    {
        var member = await _context.ScanAsync<Member>(default).GetRemainingAsync();
        return Ok(member);
    }
    [HttpPost]
    public async Task<IActionResult> CreateStudent(Member memberRequest)
    {

        var member = await _context.LoadAsync<Member>(memberRequest.Id);
        if (member != null) return BadRequest($"Student with Id {memberRequest.Id} Already Exists");
        await _context.SaveAsync(memberRequest);
        return Ok(memberRequest);
    }
    [HttpDelete("{memberId}")]
    public async Task<IActionResult> DeleteMember(int memberId)
    {
        var member = await _context.LoadAsync<Member>(memberId);
        if (member == null) return NotFound();
        await _context.DeleteAsync(member);
        return NoContent();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateStudent(Member memberRequest)
    {
        var student = await _context.LoadAsync<Member>(memberRequest.Id);
        if (student == null) return NotFound();
        await _context.SaveAsync(memberRequest);
        return Ok(memberRequest);
    }
}