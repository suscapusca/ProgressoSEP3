namespace App.DAOInterface;

public interface ITaskDAO
{
    Task UpdateTask(int id, bool status);
    Task DeleteTask(int id);
}