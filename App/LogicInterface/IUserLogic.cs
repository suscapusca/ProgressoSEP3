using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace App.LogicInterface;

public interface IUserLogic
{
    Task CreateAsync(CreateUserDTO dto);
    
    Task<List<SearchUserDTO>> LookForUsers(string username);
}