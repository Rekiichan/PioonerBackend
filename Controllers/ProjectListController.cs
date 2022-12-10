using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Pioneer_Backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProjectListController : ControllerBase
{
    private readonly IDynamoDBContext _context;
    public ProjectListController(IDynamoDBContext context)
    {
        _context = context;
    }
    // GET: api/ProjectCollection
    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var ProjectList = await _context.ScanAsync<ProjectList>(default).GetRemainingAsync();
        return Ok(ProjectList);
    }
    // GET: api/ProjectCollection/5
    [HttpGet("{projectId}")]
    public async Task<ActionResult<ProjectList>> GetByProjectId(string projectId)
    {
        var projectCollection = await _context.LoadAsync<ProjectList>(projectId);

        if (projectCollection == null)
        {
            return NotFound();
        }
        return Ok(projectCollection);
    }

    // POST: api/ProjectCollection
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ProjectList>> AddProject(ProjectList projectRequest)
    {
        var project = await _context.LoadAsync<ProjectList>(projectRequest.ProjectId);

        if (project != null) return BadRequest($"Project with Id {projectRequest.ProjectId} Already Exists");
        await _context.SaveAsync(projectRequest);
        return Ok(projectRequest);
    }

    // PUT: api/ProjectCollection/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("{projectId}")]
    public async Task<IActionResult> UpdateProject(ProjectList projectRequest, string projectId)
    {
        var project = await _context.LoadAsync<ProjectList>(projectId);
        if (project == null) return NotFound();
        await _context.SaveAsync(projectRequest);
        return Ok(projectRequest);
    }

    // DELETE: api/ProjectCollection/5
    [HttpDelete("{projectId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProject(string projectId)
    {
        var project = await _context.LoadAsync<ProjectList>(projectId);
        if (project == null) return NotFound();
        await _context.DeleteAsync(project);
        return NoContent();
    }
}
