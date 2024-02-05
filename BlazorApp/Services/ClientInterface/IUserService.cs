using BlazorApp.Pages;
using Shared.DTO;
using Shared.Model;

namespace BlazorApp.Services.ClientInterface
{
    public interface IUserService
    {
        Task<IEnumerable<Project>> GetProjectsByUsernameAsync(string? username);

        Task<List<SearchUserDTO>> LookForUsersAsync(string? usernameContains);
    }
}
