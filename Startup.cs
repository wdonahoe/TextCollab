using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TextCollab {
    public class Startup {

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services, IOptions<Settings> settings) {
            services.AddMvc();

            services.AddOptions();
            services.Configure<Settings>(Configuration.GetSection("Settings"));

            services.AddEntityFrameworkNpgsql()
                    .AddDbContext<TextContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=TextCollab;Username=text_collab_init;Password=??00+triangle+AHEAD+someone+80??"));
            //services.AddSingleton<IConfigureOptions<IServiceCollection>, DBConfiguration>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        class DBConfiguration : IConfigureOptions<IServiceCollection> {
            private readonly Settings _dbSettings;

            public DBConfiguration(IOptions<Settings> dbSettings){
                _dbSettings = dbSettings.Value;
            }

            public void Configure(IServiceCollection services){
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<TextContext>(options => options.UseNpgsql(_dbSettings.dbSettings.connectionString));
            }
        }
    }
}
