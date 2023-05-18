

var builder = WebApplication.CreateBuilder(args);
{
    var cunfig = builder.Configuration;

    builder.Services.InstallFromAssembly<Program>(cunfig);
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
