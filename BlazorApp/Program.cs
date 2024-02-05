using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp;
using BlazorApp.Services.ClientInterface;
using BlazorApp.Services.Impl;
using BlazorApp.Services;
using BlazorApp.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<BlazorApp.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IAuthService, JwtAuthService>();
builder.Services.AddScoped<IUserService, UserHttpClient>();
builder.Services.AddScoped<ICreateProjectService, ProjectHttpClient>();
builder.Services.AddScoped<ICreateTaskService, CreateTaskHttpClient>();


builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
AuthorizationPolicies.AddPolicies(builder.Services);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7156") });

builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();