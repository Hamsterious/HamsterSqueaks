using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HamsterSqueaks.Server.Data;
using HamsterSqueaks.Server.Models;
using HamsterSqueaks.Server.Services;
using Swashbuckle.AspNetCore.Swagger;
using HamsterSqueaks.Server.Swagger.Filters;

namespace HamsterSqueaks.Server
{
    /// <summary>
    /// Builds the app, its dependencies, and its request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration">Key/Value pairs of app configurations.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Key/Value pairs of app configurations.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures and add services to be used by the application.
        /// </summary>
        /// <param name="services">Services the app uses to provide functionality.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            AddDbContext(services);
            AddIdentity(services);
            AddCustomServices(services);
            services.AddMvc();
            AddSwagger(services);
        }

        /// <summary>
        /// Configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">Provides mechanisms to configure the request pipeline.</param>
        /// <param name="env">Provides information about the web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ConfigureEnvironmentBehavior(app, env);
            app.UseStaticFiles();
            app.UseAuthentication();
            ConfigureMvc(app);
            ConfigureSwagger(app);
        }

        #region Private methods
        ////////////////////////////////////////
        // Add services
        ////////////////////////////////////////
        private static void AddIdentity(IServiceCollection services)
        {
            services.AddIdentity<HamsterSqueaksUser, IdentityRole>()
                            .AddEntityFrameworkStores<HamsterSqueaksDbContext>()
                            .AddDefaultTokenProviders();
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<HamsterSqueaksDbContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddCustomServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUserService, UserService>();
        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });

                // Custom schemas
                c.SchemaFilter<BlogPostSchema>();
                c.SchemaFilter<AuthorSchema>();
            });
        }

        ////////////////////////////////////////
        // Configure pipeline
        ////////////////////////////////////////
        private static void ConfigureEnvironmentBehavior(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
            }
        }

        private static void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HamsterSqueaks");
            });
        }

        private static void ConfigureMvc(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}");
            });
        }
        #endregion
    }
}
