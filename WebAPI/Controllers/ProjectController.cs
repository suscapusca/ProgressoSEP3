using App.Logic;
using App.LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Shared.DTO;
using Shared.Model;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectLogic projectLogic;

    public ProjectController(IProjectLogic _projectLogic)
    {
        this.projectLogic = _projectLogic;
    }

   [HttpPost]
    public async Task<ActionResult> CreateAsync(CreateProjectDTO dto)
    {
        try
        {
            await projectLogic.CreateAsync(dto);
            return Created($"/project/{dto.ProjectName}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult> AddCollaborator(AddUserToProject collaborator)
    {
        try
        {
            await projectLogic.AddCollaboratorAsync(collaborator);
            return Accepted();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("userStory")]
    public async Task<ActionResult<int>> AddUserStory(TaskDTO dto)
    {
        try
        {
            int id = await projectLogic.AddUserStoryAsync(dto);
            return Ok(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteCollaborator(string username, int id)
    {
        var dto = new AddUserToProject
        {
            Username = username,
            ProjectID = id
        };
        try
        {
            await projectLogic.RemoveCollaborator(dto);
            return Ok();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [HttpGet("getCollaborators/{id:int}")]
    public async Task<ActionResult<List<SearchUserDTO>>> GetAllCollaborators([FromRoute]int id)
    {
        try
        {
            List<SearchUserDTO> list = await projectLogic.GetAllCollaborators(id);
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<List<SearchProjectDTO>>> GetAllProjects([FromRoute]string username)
    {
        try
        {
           List<SearchProjectDTO> list = await projectLogic.GetAllProjects(username);
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Tasks>>> GetProductBacklog([FromRoute] int id)
    {
        try
        {
            List<Tasks> list = await projectLogic.GetProductBacklog(id);
            return Ok(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}