using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.LogicInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shared.DTO;
using Shared.Model;


namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic userLogic;

    public UserController(IUserLogic userLogic )
    {
        this.userLogic = userLogic;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(CreateUserDTO dto)
    {
        try
        {
            await userLogic.CreateAsync(dto);
            return Created($"/user/{dto.UserName}", dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<SearchUserDTO>>> LookForUsers([FromQuery]string username)
    {
        try
        {
            var list = await userLogic.LookForUsers(username);
            return Ok(list);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    
    
}

