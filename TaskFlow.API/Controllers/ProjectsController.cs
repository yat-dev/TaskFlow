using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Services.Interfaces;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpGet("id")]
    public async Task<ActionResult<ProjectDto>> GetById(Guid id)
    {
        var project = projectService.GetByIdAsync(id);
        
        if (project == null)
            return NotFound();
        
        return Ok(project);
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetAll()
    {
        var projects = await projectService.GetAllAsync();
        
        return Ok(projects);
    }
    
    
    [HttpGet("owner/{ownerId}")]
    public async Task<ActionResult<IEnumerable<ProjectDto>>> GetByOwner(Guid ownerId)
    {
        var projects = await projectService.GetByOwnerIdAsync(ownerId);
        
        return Ok(projects);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Create(ProjectDto project)
    {
        var created = await projectService.CreateAsync(project);
        
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
    

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ProjectDto project)
    {
        if (id != project.Id) return BadRequest();
        
        await projectService.UpdateAsync(project);
        
        return NoContent();
    }
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await projectService.DeleteAsync(id);
        
        return NoContent();
    }
}