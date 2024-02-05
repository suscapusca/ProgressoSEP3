using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace App.DAOInterface;

public interface IProjectDAO
{
    Task CreateAsync(CreateProjectDTO dto);
    Task<int> AddCollaborator(AddUserToProject collaborator);
    Task<int> AddUserStory(TaskDTO dto);
    Task<List<SearchProjectDTO>> GetAllProjects(string username);
    Task<List<Tasks>> GetProductBacklog(int id);
    Task<int> RemoveCollaborator(AddUserToProject collaborator);
    Task<List<SearchUserDTO>> GetAllCollaborators(int id);
}
