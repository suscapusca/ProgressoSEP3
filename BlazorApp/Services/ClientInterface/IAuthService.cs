using System.Security.Claims;
using Shared.Model;

namespace BlazorApp.Services.ClientInterface
{
    public interface IAuthService
    {
        public Task LoginAsync(string username, string password);
        public Task LogoutAsync();
        public Task RegisterAsync(string username, string password);
        public Task<ClaimsPrincipal> GetAuthAsync();

        public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    }
}
