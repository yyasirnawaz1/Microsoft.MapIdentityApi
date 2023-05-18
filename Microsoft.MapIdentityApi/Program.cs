

var builder = WebApplication.CreateBuilder(args);
{
    // adds authorization policy services
    builder.Services.AddAuthorization();

    // class ApplicationDbContext : IdentityDbContext<IdentityUser> ...
    builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseInMemoryDatabase("dotNET8_Preview4"));

    // adds a set of common identity services to the application
    builder.Services.AddIdentityApiEndpoints<IdentityUser>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

}

var app = builder.Build();
{
    // for .NET8 Preview 4
    app.MapGroup("/identity")
            .MapIdentityApi<IdentityUser>();

    // own endpoints
    app.MapGet("/userInfo", (ClaimsPrincipal user) => $"Hello, {user.Identity?.Name}!")
        .RequireAuthorization(); // enable authorization for this endpoint
}

app.Run();
