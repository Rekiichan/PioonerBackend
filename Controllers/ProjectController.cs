using Microsoft.AspNetCore.Mvc;
using Pioneer_Backend.Service;
using Pioneer_Backend.Model;
using Pioneer_Backend.Model.UpsertModel;

namespace Pioneer_Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;
    public ProjectController(ProjectService context)
    {
        _projectService = context;
    }

    [HttpGet]
    public async Task<List<Project>> Get()
    {
        return await _projectService.GetAsyncAllProjects();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(string id)
    {
        var project = await _projectService.GetAsyncProjectById(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(ProjectUpsert newProject)
    {
        var obj = new Project()
        {
            Name= newProject.Name,
            Mssv =newProject.Mssv,
            ProjectName=newProject.ProjectName,
            YearImplement =newProject.YearImplement,
            DocumentUrl=newProject.DocumentUrl,
            ImageUrl = newProject.ImageUrl,
            Description = newProject.Description,
        };
        await _projectService.CreateAsync(obj);
        return CreatedAtAction("GetProjectById", new { id = obj.ProjectId }, obj);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateProject(Project projectRequest, string id)
    {
        var project = await _projectService.GetAsyncProjectById(id);
        if (project == null) return NotFound();
        projectRequest.ProjectId = project.ProjectId;
        await _projectService.UpdateAsync(id, projectRequest);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProject(string id)
    {
        var project = await _projectService.GetAsyncProjectById(id);
        if (project == null)
        {
            return NotFound();
        }
        await _projectService.RemoveAsync(id);
        return NoContent();
    }
}