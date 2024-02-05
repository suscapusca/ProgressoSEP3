using BlazorApp.Pages;
using BlazorApp.Services.ClientInterface;
using DataAccessClient;
using Grpc.Core;
using System.Net.Http.Json;
using System.Text.Json;
using Shared.DTO;
using Shared.Model;

namespace BlazorApp.Services.Impl
{
    public class ProjectHttpClient : ICreateProjectService
    {
        private readonly HttpClient _client;

        public ProjectHttpClient(HttpClient client)
        {
            _client = client;
        }


        public async Task<Project> Create(CreateProjectDTO dto)
        {
            var response = await _client.PostAsJsonAsync("/project", dto);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            var project = JsonSerializer.Deserialize<Project>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return project;
        }

        public async Task AddCollaborator(int projectId, string username)
        {
            var dto = new AddUserToProject()
            {
                ProjectID = projectId, Username = username,
            };

            var response = await _client.PostAsJsonAsync("api/projects/collaborators", dto);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }

        public async Task<List<SearchUserDTO>> GetAllCollaborators(int id)
        {
            var response = await _client.GetAsync($"/project/{id}/collaborator");
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
            }
            var collaborators = JsonSerializer.Deserialize<List<SearchUserDTO>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return collaborators;
        }


        public async Task RemoveCollaborator(string username, int projectId)
        {
            var response = await _client.DeleteAsync($"/project/{projectId}/collaborator/{username}");
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }

        public async Task CreateUserStory(TaskDTO dto)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"/project/{dto.ProjectId}/userStory", dto);
            string result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }

        public async Task<IEnumerable<Tasks>> GetUserStoriesAsync(int? id)
        {
            var response = await _client.GetAsync($"/project/{id}/userStory");
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
            var userStories = JsonSerializer.Deserialize<IEnumerable<Tasks>>(result,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
            return userStories;
        }

    }
}