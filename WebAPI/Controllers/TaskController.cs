using App.LogicInterface;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]/{id:int}")]
public class TaskController : ControllerBase
{
    private readonly ITaskLogic TaskLogic;

    public TaskController(ITaskLogic taskLogic)
    {
        TaskLogic = taskLogic;
    }
    
    [HttpPatch("update")]
    public async Task<ActionResult> UpdateTask([FromRoute] int id, bool status)
    {
        try
        {
            await TaskLogic.UpdateTask(id , status);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult> DeleteTask([FromRoute] int id)
    {
        try
        {
            await TaskLogic.DeleteTask(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}