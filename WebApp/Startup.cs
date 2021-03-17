using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using DAL.App.EF;
using DAL.App.EF.AppDataInit;
using DAL.App.EF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Helpers;

namespace WebApp
{
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
            services.AddDbContext<AppDbContext>(options =>
                options
                    .UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"))
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
            );
            
            services.AddScoped<IDisputeRepository, DisputeRepository>();
            
            
            services.AddSingleton<Singleton>();
            services.AddTransient<Transient>();
            services.AddScoped<Scoped>();
            
            services.AddTransient<IDiTransient, Transient>();
            services.AddSingleton<IDiSingleton, Singleton>();
            services.AddScoped<IDiScoped, Scoped>();
            
            
            
            services.AddDatabaseDeveloperPageExceptionFilter();
            
            
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        private static void SetupAppData(IApplicationBuilder app, IConfiguration configuration)
        {
            using var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var ctx = serviceScope.ServiceProvider.GetService<AppDbContext>();

            if (ctx == null) return;
            
            if (configuration.GetValue<bool>("AppData:DropDatabase"))
            {
                DataInit.DropDatabase(ctx);
            }

            if (configuration.GetValue<bool>("AppData:Migrate"))
            {
                DataInit.MigrateDatabase(ctx);
            }

            if (configuration.GetValue<bool>("AppData:SeedIdentity"))
            {
                // TODO
            }

            //C# will dispose all the usings here
        }

    }
}