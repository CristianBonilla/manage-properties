using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstate.Properties.API.Modules;
using RealEstate.Properties.API.Options;
using Autofac;

namespace RealEstate.Properties.API
{
    public class Startup
    {
        readonly IWebHostEnvironment env;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesFromAssembly(Configuration, env);
        }

        // Register your own things directly with Autofac here.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DomainModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                SwaggerOptions swagger = Configuration.GetSection(nameof(SwaggerOptions)).Get<SwaggerOptions>();
                app.UseSwagger(options => options.RouteTemplate = swagger.JsonRoute);
                app.UseSwaggerUI(c => c.SwaggerEndpoint(swagger.UIEndpoint, swagger.Description));
            }

            app.UseCors(CommonValues.AllowOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
