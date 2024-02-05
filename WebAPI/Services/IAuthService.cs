using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}