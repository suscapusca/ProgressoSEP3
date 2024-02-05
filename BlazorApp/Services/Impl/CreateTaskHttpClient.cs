using System.Net.Http.Json;
using BlazorApp.Services.ClientInterface;
using Shared.DTO;

namespace BlazorApp.Services.Impl

{
    public class CreateTaskHttpClient : ICreateTaskService


    {

        private readonly HttpClient _client;

        public CreateTaskHttpClient(HttpClient _client)
        {
            _client = _client;
        }



        public async Task CreateTask(CreateTaskDTO dto)
        {
            var response = await _client.PostAsJsonAsync("api/tasks", dto);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }

        public async Task UpdateTask(int id, bool status)
        {
            var response = await _client.PutAsJsonAsync($"api/tasks/{id}", status);
            var result = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }

        public async Task DeleteTask(int id)
        {
            var response = await _client.DeleteAsync($"api/tasks/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                throw new Exception(result);
            }
        }
    }
}
