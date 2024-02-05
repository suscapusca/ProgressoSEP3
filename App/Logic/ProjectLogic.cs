using App.DAOInterface;
using App.LogicInterface;
using Shared.DTO;
using Shared.Model;
using Task = System.Threading.Tasks.Task;

namespace App.Logic;

public class ProjectLogic : IProjectLogic
{
    private readonly IProjectDAO ProjectDao;

    public ProjectLogic(IProjectDAO projectDao)
    {
        ProjectDao = projectDao;
    }
    public async Task CreateAsync(CreateProjectDTO dto)
    {
        await ProjectDao.CreateAsync(dto);
    }

    public async Task AddCollaboratorAsync(AddUserToProject collaborator)
    {
        await ProjectDao.AddCollaborator(collaborator);;
    }

    public async Task<int> AddUserStoryAsync(TaskDTO dto)
    {
        return await ProjectDao.AddUserStory(dto);
    }

    public async Task<List<SearchProjectDTO>> GetAllProjects(string username)
    {
        return await ProjectDao.GetAllProjects(username);
    }

    public async Task<List<Tasks>> GetProductBacklog(int id)
    {
        return await ProjectDao.GetProductBacklog(id);
    }

    public async Task<List<SearchUserDTO>> GetAllCollaborators(int id)
    {
        return await ProjectDao.GetAllCollaborators(id);
    }

    public async Task<int> RemoveCollaborator(AddUserToProject collaborator)
    {
        return await ProjectDao.RemoveCollaborator(collaborator);
    }
}