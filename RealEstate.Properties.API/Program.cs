using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using RealEstate.Properties.Domain.Context;

namespace RealEstate.Properties.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            await DbMigrationStart<PropertiesContext>(host);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task DbMigrationStart<TContext>(IHost host) where TContext : DbContext
        {
            using IServiceScope serviceScope = host.Services.CreateScope();
            TContext dbContext = serviceScope.ServiceProvider.GetRequiredService<TContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
