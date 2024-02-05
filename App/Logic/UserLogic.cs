using App.DAOInterface;
using App.LogicInterface;
using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace App.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDAO UserDao;

    public UserLogic(IUserDAO userDao)
    {
        this.UserDao = userDao;
    }

    public async Task CreateAsync(CreateUserDTO dto)
    {
        await UserDao.CreateUserAsync(dto);
    }

    public async Task<List<SearchUserDTO>> LookForUsers(string username)
    {
        return await UserDao.LookForUsers(username);
    }
}