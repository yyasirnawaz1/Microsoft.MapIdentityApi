namespace Microsoft.MapIdentityApi.Installers;

public class InfrastructureInstaller : IServiceCollectionInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        // class ApplicationDbContext : IdentityDbContext<IdentityUser> ...
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseInMemoryDatabase("dotNET8_Preview4"));
    }
}
