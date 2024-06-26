using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Authentication;
using ValhallaVaultCyberAwareness.Client.Services;
using ValhallaVaultCyberAwareness.Components;
using ValhallaVaultCyberAwareness.Components.Account;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Managers;
using ValhallaVaultCyberAwareness.Middlewares;
using ValhallaVaultCyberAwareness.Repositories;
using ValhallaVaultCyberAwareness.Repositories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

//Repositories
builder.Services.AddScoped<ISegmentRepository, SegmentRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IUserAnswersRepository, UserAnswersRepository>();
builder.Services.AddScoped<IAnswersRepository, AnswersRepository>();
builder.Services.AddScoped<ISupportQuestionRepository, SupportQuestionRepository>();
builder.Services.AddScoped<ISupportResponseRepository, SupportResponseRepository>();

//Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISegmentService, SegmentService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<ISupportQuestionService, SupportQuestionService>();
builder.Services.AddScoped<ISupportResponseService, SupportResponseService>();
builder.Services.AddScoped<ValhallaHeaderService>();
builder.Services.AddScoped<AdminManager>();
builder.Services.AddScoped<IUserAnswersService, UserAnswersService>();

builder.Services.AddBlazorBootstrap();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddControllers();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!)
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Transient);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
    });
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

using (ServiceProvider sp = builder.Services.BuildServiceProvider())
{
    var context = sp.GetRequiredService<ApplicationDbContext>();
    var signInManager = sp.GetRequiredService<SignInManager<ApplicationUser>>();
    var roleManager = sp.GetRequiredService<RoleManager<IdentityRole>>();

    context.Database.Migrate();

    ApplicationUser newAdmin = new()
    {
        UserName = "admin",
        Email = "adminuser@mail.com",
        EmailConfirmed = true
    };

    ApplicationUser newUser = new()
    {
        UserName = "user",
        Email = "user@mail.com",
        EmailConfirmed = true

    };

    var admin = signInManager.UserManager.FindByEmailAsync(newAdmin.Email).GetAwaiter().GetResult();

    if (admin == null)
    {
        // Skapa en ny user 
        signInManager.UserManager.CreateAsync(newAdmin, "Password1234!").GetAwaiter().GetResult();

        // Kolla om admin rollen existerar
        bool adminRoleExists = roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult();

        if (!adminRoleExists)
        {
            IdentityRole adminRole = new()
            {
                Name = "Admin"
            };

            // Skapa adminrollen
            roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();

            // Tilldela adminrollen till den nya admin-usern
            signInManager.UserManager.AddToRoleAsync(newAdmin, "Admin").GetAwaiter().GetResult();

        }

    }

    var user = signInManager.UserManager.FindByEmailAsync(newUser.Email).GetAwaiter().GetResult();

    if (user == null)
    {
        signInManager.UserManager.CreateAsync(newUser, "Password1234!").GetAwaiter().GetResult();
    }
}

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<BasicAuthHandler>("BasicAuth");
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(ValhallaVaultCyberAwareness.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
