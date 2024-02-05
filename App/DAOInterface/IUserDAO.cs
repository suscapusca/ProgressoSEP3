using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;


namespace App.DAOInterface;

public interface IUserDAO
{
    Task CreateUserAsync(CreateUserDTO dto);
    Task<User?> GetByUsernameAsync(LoginDTO loginDto);
    
    Task<List<SearchUserDTO>> LookForUsers(string username);
    
    
}