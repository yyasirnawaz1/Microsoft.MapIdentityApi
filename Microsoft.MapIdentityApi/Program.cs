

var builder = WebApplication.CreateBuilder(args);
{
    var config = builder.Configuration;

    builder.Services.InstallFromAssembly<Program>(config);
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
