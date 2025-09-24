using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientPortalBackend.Utils;
using System;

namespace PatientPortalBackend
{
    public class Startup
    {
        private IWebHostEnvironment _env;

        public static IConfiguration AppSettings { get; private set; }
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            AppSettings = configuration;
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var corsSettings = AppSettings.GetSection("CORS");
            var enableCorsStr = corsSettings["Enable"] ?? String.Empty;
            bool enableCors = true;
            if(bool.TryParse(enableCorsStr, out var tmp))
            {
                enableCors = tmp;
            }
            var allowedCorsOrigins = corsSettings["AllowedOrigins"];

            services.Configure<PortalSettings >(Configuration.GetSection("PortalSettings"));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        if (enableCors)
                        {
                            if (String.IsNullOrWhiteSpace(allowedCorsOrigins))
                            {
                                builder.AllowAnyOrigin();
                            }
                            else
                            {
                                var splt = allowedCorsOrigins.Split(';');
                                builder.WithOrigins(splt);
                            }
                        }

                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddHttpClient();
            services.AddControllers();
            //services.AddResponseCompression(options =>
            //{
            //    options.EnableForHttps = true;
            //    options.Providers.Add<BrotliCompressionProvider>();
            //    options.Providers.Add<GzipCompressionProvider>();
            //});

            //var jsonCompressionLevel = GetJsonCompressionLevel();

            //services.Configure<GzipCompressionProviderOptions>(options =>
            //{
            //    options.Level = jsonCompressionLevel;
            //});

            //services.Configure<BrotliCompressionProviderOptions>(options =>
            //{
            //    options.Level = jsonCompressionLevel;
            //});

            //var msgPackCompressionLevel = GetMsgPackCompressionLevel();
            //services.AddMessagePack(opt =>
            //{
            //    opt.Compression = msgPackCompressionLevel;
            //}
            //);

            //services.AddSignalR();

            //try
            //{
            //    LoadMedCubesModulesAndAddControllers(services);
            //}
            //catch (Exception e)
            //{
            //    File.WriteAllText(@"D:\ERROR.txt", e.ToString());
            //    throw;
            //}

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedCubes.Framework.Server", Version = "v1" });
            //});

            // TODO .Net 5: Temporary solution for EF6
            // Should be solved with EF Core and dependency injection

            AddConnectionStrings();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAllOrigins");

            //app.services.Configure<PortalSettings>(builder.Configuration.GetSection("PortalSettings"));

            //app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedCubes.Framework.Server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseAuthorization();
        }

        private void AddConnectionStrings()
        {
            var connectionStrings = ConnectionStringProperties.GetInstance;
            var connStrsCfg = AppSettings.GetSection("ConnectionStrings");
            foreach (var entry in connStrsCfg.GetChildren())
            {
                connectionStrings.AddConnectionString(entry.Key, entry.Value);
            }
        }
    }
}
