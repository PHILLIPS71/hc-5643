using HC_5643.Persistence;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace HC_5643;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _environment;

    public Startup(IConfiguration configuration, IHostEnvironment env)
    {
        _configuration = configuration;
        _environment = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddDbContextPool<ApplicationDbContext>((provider, options) =>
            {
                options
                    .UseNpgsql(_configuration.GetConnectionString(name: "DatabaseConnection"),
                        o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

        services
            .AddPooledDbContextFactory<ApplicationDbContext>((provider, options) =>
            {
                options
                    .UseNpgsql(_configuration.GetConnectionString(name: "DatabaseConnection"),
                        o => o.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

        services
            .AddGraphQLServer()
            .RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
            .AddQueryType()
            .AddHC_5643Types()
            .AddProjections()
            .AddFiltering()
            .AddSorting();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (!_environment.IsDevelopment())
            app.UseHttpsRedirection();

        app
            .UseRouting()
            .UseWebSockets()
            .UseEndpoints(endpoint =>
                endpoint
                    .MapGraphQL()
                    .WithOptions(new GraphQLServerOptions
                    {
                        Tool = { Enable = _environment.IsDevelopment() }
                    })
            );
    }
}