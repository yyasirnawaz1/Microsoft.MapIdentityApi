# Microsoft.MapIdentityApi

MapIdentityApi<TUser> is an extension method to simplify the process of using ASP.NET Core Identity for authentication in JavaScript-based single page apps or Blazor apps.




## Step 1 - Create your identity context

```nuget
 dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```
```csharp
public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
```


## Step 2 - Setting up authorization services in `Program.cs`

```csharp
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
```


## Step 3 - Map identity endpoint group
```csharp
var app = builder.Build();
// for .NET8 Preview 4
app.MapGroup("/Identity")
        .MapIdentityApi<IdentityUser>();
```


#### Notice - Adds the default authorization policy to the endpoint(s).
```csharp
// own endpoints
app.MapGet("/userInfo", (ClaimsPrincipal user) => $"Hello, {user.Identity?.Name}!")
    .RequireAuthorization(); // enable authorization for this endpoint
```

## Step 4 - Register New User
```javascript
// register new user

POST https://localhost:7202/identity/register
Content-Type: application/json
Accept-Language: en-US,en;q=0.5

{
    "username" : "thisisnabi@outlook.com",
    "password" : "ThiSisNabi@1122t"
}
```


## Step 5 - Login 
```javascript
// login and get access token 
POST https://localhost:7202/identity/login
Content-Type: application/json
Accept-Language: en-US,en;q=0.5

{
    "username" : "thisisnabi@outlook.com",
    "password" : "ThiSisNabi@1122t"
}

// response
#Content:
{
  "token_type": "Bearer",
  "access_token": "CfDJ8IldTW6L6lhO..........",
  "expires_in": 3600
}
```

