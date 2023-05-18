namespace Microsoft.MapIdentityApi.Installers;

public class AuthenticationInstaller : IServiceCollectionInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // adds authorization policy services
        services.AddAuthorization();

        // adds a set of common identity services to the application
        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
    }
}
