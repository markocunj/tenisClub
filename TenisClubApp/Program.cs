using TC.DomainModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TC.DAL.SeedData;

namespace TenisClubApp
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;

        public static readonly string AppName = Namespace;

        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            Log.Logger = CreateSerilogLogger(configuration);

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("hr-HR");
                System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                customCulture.NumberFormat.NumberDecimalSeparator = ",";

                System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
                Log.Information("Configuring web host ({ApplicationContext})...", AppName);

                var host = CreateHostBuilder(args).Build();


                using (var newScope = host.Services.CreateScope())
                {

                    var myDbContext = newScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    myDbContext.Database.Migrate();
                    myDbContext.Database.EnsureCreated();

                    //SEED
                    CourtSeed.SeedCourts(myDbContext);
                    MembershipTypesSeed.SeedMembershipTypes(myDbContext);
                }
                host.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                Console.WriteLine(ex.Message);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();

        }

        private static ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            var appInstanceName = configuration["InstanceName"];
            var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var SendToSyslog = Convert.ToBoolean(configuration["SendToSyslog"]);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("Application", appInstanceName)
                .Enrich.WithProperty("Environment", environment)
                .Enrich.FromLogContext()
                .Enrich.WithCorrelationId()

                .Enrich.WithCorrelationIdHeader()
                .Enrich.WithEnvironment(environment)
                ;

           

            return logger.CreateLogger();
        }
      
    }
}
