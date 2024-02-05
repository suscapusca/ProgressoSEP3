using App.DAOInterface;
using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly IUserDAO UserDao;

    public AuthService(IUserDAO userDao)
    {
        UserDao = userDao;
    }
    public async Task<User> ValidateUser(string username, string password)
    {
        LoginDTO loginDto = new LoginDTO
        {
            Username = username,
            Password = password
        };

        User? existingUser =  await UserDao.GetByUsernameAsync(loginDto);
        /*User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));*/
        // string realPassword = await _userDao.GetUserPassword(loginDto);


        if (existingUser == null)
        {
            throw new Exception("User doesn't exist");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return await Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        CreateUserDTO dto = new CreateUserDTO
        {
            UserName = user.UserName,
            Password = user.Password
        };
        UserDao.CreateUserAsync(dto);
        return Task.CompletedTask;
    }
}