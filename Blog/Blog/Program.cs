using Blog.Data;
using Blog.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog.Web;

namespace Blog
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AplicationDbContext>();

                    var userManager = services.GetRequiredService<UserManager<User>>();//initialse admin
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await RoleInitialiser.Initialiser(userManager, rolesManager);

                    SampleData.Initialise(context);//initialse category
                }
                catch (Exception ex)
                {
                    var loger = services.GetRequiredService<ILogger<Program>>();
                    loger.LogError(ex, "Error in system can not initialise data");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }).ConfigureLogging(
                    loging =>
                    {
                        loging.ClearProviders();
                        loging.SetMinimumLevel(LogLevel.Trace);
                    }
                ).UseNLog();
    }
}
