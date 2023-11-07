using AzureFunction.Models.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
     .ConfigureAppConfiguration(x => x.AddEnvironmentVariables())
    .ConfigureHostConfiguration(x => x.AddEnvironmentVariables())
    .ConfigureServices(services =>
    {
        services.AddSingleton<HttpClient>();
        services.AddDbContext<SchoolContext>(
            x =>
            {
                var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
                x.UseSqlServer(connectionString);            
            }
        );
    })
    .Build();


host.Run();
