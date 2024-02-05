using App.DAOInterface;
using App.LogicInterface;

namespace App.Logic;

public class TaskLogic : ITaskLogic
{
    private readonly ITaskDAO _taskDao;

    public TaskLogic(ITaskDAO taskDao)
    {
        _taskDao = taskDao;
    }
    public async Task UpdateTask(int id, bool status)
    {
        await _taskDao.UpdateTask(id, status);
    }

    public async Task DeleteTask(int id)
    {
        await _taskDao.DeleteTask(id);
    }
}