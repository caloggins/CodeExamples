using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestingExamples.ApiTests;

public class TestProfilesApiApplication : WebApplicationFactory<Program>
{
    // private SqliteConnection? connection;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(config =>
        {
            // load config stuff here
        });
        
        builder.ConfigureTestServices(services =>
        {
            RemoveProductionDatabase(services);

            // connection = new SqliteConnection("DataSource=:memory:");
            // connection.Open();
            //
            // services.AddDbContext<UserAccountContext>(
            //     o => o.UseSqlite(connection));
            // services.AddDbContext<UserProfileContext>(
            //     o => o.UseSqlite(connection));
            //
            // services
            //     .AddAuthentication(options =>
            //     {
            //         options.DefaultAuthenticateScheme = TestAuthenticationHandler.AuthenticationScheme;
            //         options.DefaultChallengeScheme = TestAuthenticationHandler.AuthenticationScheme;
            //     })
            //     .AddScheme<AuthenticationSchemeOptions, TestAuthenticationHandler>(
            //         TestAuthenticationHandler.AuthenticationScheme,
            //         options => { });
        });
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        // connection?.Dispose();
    }

    private static void RemoveProductionDatabase(IServiceCollection services)
    {
        // Pay atttention, you need to remove the DbContextOptions<T>
        // not the DbContext class.
        // RemoveService<DbContextOptions<UserAccountContext>>(services);
        // RemoveService<DbContextOptions<UserProfileContext>>(services);
    }

    private static void RemoveService<TType>(IServiceCollection services)
    {
        var descriptor = services.SingleOrDefault(o =>
            o.ServiceType == typeof(TType));
        services.Remove(descriptor!);
    }
}