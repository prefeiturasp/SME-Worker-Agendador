using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace SME.Worker.Agendador.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(options =>
            {
                options.SetBasePath(Directory.GetCurrentDirectory());
                options.AddUserSecrets<Program>();
                options.AddEnvironmentVariables();
            })
            .ConfigureLogging((HostBuilderContext context, ILoggingBuilder log) =>
            {
                log.AddConfiguration(context.Configuration);
                //log.AddSentry();
            })
            //.ConfigureServices(WorkerService.Initialize);
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
