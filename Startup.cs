namespace UnobsTaskExc;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddOutputCache();
        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            e.SetObserved();
        };
    }

    public void Configure(IApplicationBuilder app, IHostEnvironment env, ILogger<Startup> logger)
    {
        app.UseRouting();
        app.UseOutputCache();

        app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
    }
}