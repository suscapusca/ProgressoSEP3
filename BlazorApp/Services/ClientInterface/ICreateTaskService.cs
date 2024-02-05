using Shared.DTO;

namespace BlazorApp.Services.ClientInterface
{
    public interface ICreateTaskService
    {
        Task CreateTask(CreateTaskDTO dto);
        Task UpdateTask(int id, bool status);
        Task DeleteTask(int id);
    }
}
