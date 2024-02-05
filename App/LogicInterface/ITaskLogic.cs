namespace App.LogicInterface;

public interface ITaskLogic
{
    Task UpdateTask(int id, bool status);
    Task DeleteTask(int id);
}