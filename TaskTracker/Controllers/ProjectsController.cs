using Microsoft.AspNetCore.Mvc;
using TaskTracker.Data;
using TaskTracker.Models;

namespace TaskTracker.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly TrackerMemory _memory;

    public ProjectsController(TrackerMemory memory)
    {
        _memory = memory;
    }

    [HttpGet]
    public ActionResult<List<Project>> GetAll()
    {
        return _memory.Projects;
    }

    [HttpGet("{id}")]
    public ActionResult<Project> GetById(int id)
    {
        var project = _memory.Projects.FirstOrDefault(project => project.Id == id);
        if (project is null)
        {
            return NotFound();
        }

        return project;
    }

    [HttpGet("{id}/tasks")]
    public ActionResult<List<TaskItem>> GetTasks(int id)
    {
        var project = _memory.Projects.FirstOrDefault(project => project.Id == id);
        if (project is null)
        {
            return NotFound();
        }

        return project.Tasks;
    }

    [HttpPost]
    public ActionResult<Project> Create(CreateProjectRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var project = new Project
        {
            Id = NextProjectId(),
            Name = request.Name.Trim(),
            Description = request.Description,
            CreatedAt = DateTime.Now
        };

        _memory.Projects.Add(project);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public ActionResult<Project> Update(int id, UpdateProjectRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return BadRequest("Name is required.");
        }

        var project = _memory.Projects.FirstOrDefault(project => project.Id == id);
        if (project is null)
        {
            return NotFound();
        }

        project.Name = request.Name.Trim();
        project.Description = request.Description;
        return project;
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var project = _memory.Projects.FirstOrDefault(project => project.Id == id);
        if (project is null)
        {
            return NotFound();
        }

        _memory.Projects.Remove(project);
        return NoContent();
    }

    private int NextProjectId()
    {
        if (_memory.Projects.Count == 0)
        {
            return 1;
        }

        return _memory.Projects.Max(project => project.Id) + 1;
    }
}
