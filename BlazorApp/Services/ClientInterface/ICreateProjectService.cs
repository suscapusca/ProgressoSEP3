using BlazorApp.Pages;
using DataAccessClient;
using Shared.DTO;
using Shared.Model;

namespace BlazorApp.Services.ClientInterface
{
    public interface ICreateProjectService
    {
        Task<Project> Create(CreateProjectDTO dto);


        Task AddCollaborator(int projectId, string username);

        Task<List<SearchUserDTO>> GetAllCollaborators(int id);

        Task RemoveCollaborator(string username, int projectId);

        Task CreateUserStory(TaskDTO dto);
        Task<IEnumerable<Tasks>> GetUserStoriesAsync(int? id = null);
    }
}
