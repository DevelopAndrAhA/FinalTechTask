using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Persistence;

namespace TechWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<TechDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }
            host.Run();
        }

        public static IHostBuilder CreateBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
