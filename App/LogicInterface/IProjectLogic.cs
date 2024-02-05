using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace App.LogicInterface;

public interface IProjectLogic
{
    Task CreateAsync(CreateProjectDTO dto);
    Task AddCollaboratorAsync(AddUserToProject collaborator);
    Task<int> AddUserStoryAsync(TaskDTO dto);
    Task<List<SearchProjectDTO>> GetAllProjects(string username);
    Task<List<Tasks>> GetProductBacklog(int id);
    
    Task<List<SearchUserDTO>> GetAllCollaborators(int id);
    Task<int> RemoveCollaborator(AddUserToProject collaborator);
}