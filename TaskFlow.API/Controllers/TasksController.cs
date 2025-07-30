using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Services.Interfaces;

namespace TaskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController(ITaskService taskService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<TaskDto>> GetAllAsync() => await taskService.GetAllAsync();
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDto>> GetById(Guid id) {var task = await taskService.GetByIdAsync(id);
        return task is null ? NotFound() : Ok(task);
    }

    [HttpGet("project/{projectId}")]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetByProject(Guid projectId)
    {
        var tasks = await taskService.GetByProjectIdAsync(projectId);
        return Ok(tasks);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetByAssignedUser(Guid userId)
    {
        var tasks = await taskService.GetByAssignedUserIdAsync(userId);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(TaskDto task)
    {
        var created = await taskService.CreateAsync(task);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, TaskDto task)
    {
        if (id != task.Id) return BadRequest();
        await taskService.UpdateAsync(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await taskService.DeleteAsync(id);
        return NoContent();
    }
}