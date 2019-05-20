using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Due.Models.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Due
{
    public class ConnectionStringBuilder
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Template = "Server={0};Database={1};Port=5432;User Id={2};Password={3};Ssl Mode=Require;";

        public string BuildConnectionString()
        {
            return String.Format(Template,
                                 Server,
                                 Database,
                                 User,
                                 Password);
        }

    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var configuration = new ConfigurationBuilder()
              .AddEnvironmentVariables()
              .Build();

            ConnectionStringBuilder builder = new ConnectionStringBuilder()
            {
                Database = configuration.GetSection("PG_DB").Value,
                Server = configuration.GetSection("PG_SERVER").Value,
                User = configuration.GetSection("PG_USER").Value,
                Password = configuration.GetSection("PG_PASS").Value,
            };

            string connectionString = builder.BuildConnectionString();

            Console.WriteLine($"string {connectionString}");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<DatabaseContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}