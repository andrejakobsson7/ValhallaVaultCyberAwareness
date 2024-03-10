using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ValhallaVaultCyberAwareness.Client;
using ValhallaVaultCyberAwareness.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7107/"),
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISegmentService, SegmentService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IUserAnswersService, UserAnswersService>();

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

await builder.Build().RunAsync();
