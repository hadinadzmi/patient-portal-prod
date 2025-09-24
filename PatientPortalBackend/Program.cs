
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientPortalBackend.Utils;

namespace PatientPortalBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                            optional: true, reloadOnChange: true);

                    //config.AddJsonFile("configurationsettings.json", optional: true, reloadOnChange: true)
                    //    .AddJsonFile($"configurationsettings.{env.EnvironmentName}.json",
                    //        optional: true, reloadOnChange: true);

                    config.AddJsonFile("connectionstrings.json", optional: true, reloadOnChange: true);
                        //.AddJsonFile($"connectionstrings.{env.EnvironmentName}.json",
                        //    optional: true, reloadOnChange: true);

                    //config.AddJsonFile("databasesettings.json", optional: true, reloadOnChange: true)
                    //    .AddJsonFile($"databasesettings.{env.EnvironmentName}.json",
                    //        optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        //public static void Main(string[] args)
        //{

        //    var builder = WebApplication.CreateBuilder(args);


        //    // Add services to the container.

        //    builder.Services.AddControllers();
        //    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //    builder.Services.AddEndpointsApiExplorer();
        //    builder.Services.AddSwaggerGen();
        //    builder.Services.AddHttpClient();
        //    builder.Configuration.AddJsonFile("connectionStrings.json", optional: false, reloadOnChange: true);
        //    builder.Services.Configure<PortalSettings>(builder.Configuration.GetSection("PortalSettings"));
            
        //    var app = builder.Build();

        //    // Configure the HTTP request pipeline.
        //    if (app.Environment.IsDevelopment())
        //    {
        //        app.UseSwagger();
        //        app.UseSwaggerUI();
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseAuthorization();


        //    app.MapControllers();

        //    app.Run();
        //}

        //private void AddConnectionStrings()
        //{
        //    var connectionStrings = ConnectionStringProperties.GetInstance;
        //    var connStrsCfg = AppSettings.GetSection("ConnectionStrings");
        //    foreach (var entry in connStrsCfg.GetChildren())
        //    {
        //        connectionStrings.AddConnectionString(entry.Key, entry.Value);
        //    }
        //}
    }


}
