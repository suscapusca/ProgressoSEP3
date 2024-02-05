using App.DAOInterface;
using DataAccessClient;
using Grpc.Net.Client;
using Shared.DTO;
using Shared.Model;

namespace DataAccess.DAO;

public class ProjectDAO : IProjectDAO
{
    private ProjectAccess.ProjectAccessClient client;

    public ProjectDAO()
    {
        var channel = GrpcChannel.ForAddress("http://localhost:8080");
        Console.WriteLine(channel.State);
        client = new ProjectAccess.ProjectAccessClient(channel);
    }
    public async Task CreateAsync(Shared.DTO.CreateProjectDTO dto)
    {
        ProjectCreationDto request = new ProjectCreationDto
        {
            OwnerUsername = dto.owner,
            Title = dto.ProjectName
        };
        await client.CreateProjectAsync(request);
    }

    public Task<int> AddCollaborator(AddUserToProject collaborator)
    {
        AddToProjectDto dto = new AddToProjectDto
        {
            Username = collaborator.Username,
            ProjectId = collaborator.ProjectID
        };
        var response = client.AddCollaborator(dto);
        return Task.FromResult(response.Code);
    }

    public Task<int> AddUserStory(TaskDTO dto)
    {
        UserStoryMessage userStory = new UserStoryMessage
        {
            ProjectId = dto.ProjectId,
            TaskBody = dto.Title
        };
        ResponseWithID responseWithId = client.AddUserStory(userStory);
        return Task.FromResult(responseWithId.Id);
    }

    public Task<List<SearchProjectDTO>> GetAllProjects(string username)
    {
        var projectsResponse = client.GetAllProjects(new Username { Username_ = username });
        List<SearchProjectDTO> list = new List<SearchProjectDTO>();
        foreach (var project in projectsResponse.Projects)
        {
            list.Add(new SearchProjectDTO(){Id = project.Id, Title = project.Title});
        }

        return Task.FromResult(list);
    }

    public Task<List<Tasks>> GetProductBacklog(int id)
    {
        var productBacklog = client.GetProductBacklog(new Id(){Id_ = id});
        List<Tasks> list = new List<Tasks>();
        foreach (var story in productBacklog.UserStories)
        {
            list.Add(new Tasks{id = story.Id , Title = story.UserStory_ , projectId = story.ProjectId});
        }

        return Task.FromResult(list);
    }

    public Task<int> RemoveCollaborator(AddUserToProject collaborator)
    {
        AddToProjectDto dto = new AddToProjectDto
        {
            Username = collaborator.Username,
            ProjectId = collaborator.ProjectID
        };
        var response = client.RemoveCollaborator(dto);
        return Task.FromResult(response.Code);
    }

    public Task<List<SearchUserDTO>> GetAllCollaborators(int id)
    {
        var collaboratorsResponse = client.GetAllCollaborators(new Id { Id_ = id });
        List<SearchUserDTO> list = new List<SearchUserDTO>();
        foreach (var user in collaboratorsResponse.Users)
        {
            list.Add(new SearchUserDTO(){UsernameContains = user.Username});
        }

        return Task.FromResult(list);
    }
}