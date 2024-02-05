using App.DAOInterface;
using Shared.DTO;
using Shared.Model;
using Grpc.Net.Client;
using DataAccessClient;
using UserCreationDto = DataAccessClient.UserCreationDto;
using LoginDto = Shared.DTO.LoginDTO;
using Task = System.Threading.Tasks.Task;

namespace DataAccess.DAO;

public class UserDAO : IUserDAO
{
    private UserAccess.UserAccessClient Client;

    public UserDAO()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:8080");
        Console.WriteLine(channel.State);
        Client = new UserAccess.UserAccessClient(channel);
    }

    public async Task CreateUserAsync(Shared.DTO.CreateUserDTO dto)
    {
        UserCreationDto createUserDto = new UserCreationDto()
        {
            Password = dto.Password,
            Username = dto.UserName
        };

        var call = Client.CreateUser(createUserDto);
    }

    public Task<User?> GetByUsernameAsync(LoginDTO loginDto)
    {
        Username username = new Username
        {
            Username_ = loginDto.Username
        };
        var call = Client.UserByUsername(username);
        User result = new User
        {
           UserName = call.Username,
           Password = call.Password
        };
        return Task.FromResult(result);
    }

    public Task<List<SearchUserDTO>> LookForUsers(string username)
    {
        Username request = new Username
        {
            Username_ = username
        };
        var call = Client.LookForUsers(request);
        List<SearchUserDTO> list = new();
        foreach (var user in call.Users)
        {
           list.Add(new SearchUserDTO
               {
                   UsernameContains = user.Username
               }
               );
        }

        return Task.FromResult(list);
    }
}
