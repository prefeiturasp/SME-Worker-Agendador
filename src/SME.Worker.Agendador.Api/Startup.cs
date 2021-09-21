using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SME.Worker.Agendador.Api.Services;
using SME.Worker.Agendador.Hangfire.Configurations;

namespace SME.Worker.Agendador.Api
{
    public class Startup
    {
        private IApplicationBuilder app;

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SME.Worker.Agendador.Api", Version = "v1" });
            });


            var hangfireConnectionString = Configuration.GetConnectionString("SGP_Redis");
            WorkerService.Initialize(Configuration, services, hangfireConnectionString);

            WorkerConfiguration.Configure(services, hangfireConnectionString);
            services.AddHangfireServer();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.app = app;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SME.Worker.Agendador.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DashboardConfiguration.Configure(app, Configuration);
        }
    }
}
