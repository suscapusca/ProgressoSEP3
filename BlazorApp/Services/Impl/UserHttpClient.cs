using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using BlazorApp.Pages;
using BlazorApp.Services.ClientInterface;
using Shared.DTO;

namespace BlazorApp.Services.Impl
{
    public class UserHttpClient : IUserService
    {
        private readonly HttpClient _client;

        public UserHttpClient(HttpClient _client)
        {
            _client = _client;
        }

        public async Task<IEnumerable<Project>> GetProjectsByUsernameAsync(string? username)
        {
            var uri = username == null ? "api/projects" : $"api/projects/{username}";

            var response = await _client.GetAsync(uri);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            var projects = JsonSerializer.Deserialize<IEnumerable<Project>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return projects;
        }

        public async Task<List<SearchUserDTO>> LookForUsersAsync(string? usernameContains)
        {
            var response = await _client.GetAsync($"/user/search?username={usernameContains}");
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }

            var users = JsonSerializer.Deserialize<List<SearchUserDTO>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return users;
        }
    }
}