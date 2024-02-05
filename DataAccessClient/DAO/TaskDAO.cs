using App.DAOInterface;
using DataAccessClient;
using Grpc.Net.Client;

namespace DataAccess.DAO;

public class TaskDAO : ITaskDAO

{
    private readonly ProjectAccess.ProjectAccessClient _client;

    public TaskDAO()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:8080");
        Console.WriteLine(channel.State);
        _client = new ProjectAccess.ProjectAccessClient(channel);
    }
    public async Task UpdateTask(int id, bool status)
    {
        var request = new StatusUpdate
        {
            Id = id ,
            Status = status
        };
        await _client.UpdateUserStoryStatusAsync(request);
    }

    public async Task DeleteTask(int id)
    {
        var request = new Id
        {
            Id_ = id
        };
        await _client.DeleteUserStoryAsync(request);
    }
}