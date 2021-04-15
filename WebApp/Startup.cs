using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using BLL.App;
using DAL.App.EF;
using DAL.App.EF.AppDataInit;
using DAL.App.EF.Repositories;
using Domain.App.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
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
            
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();
            services.AddScoped<IAppBLL, AppBLL>();
            
            
            services.AddSingleton<Singleton>();
            services.AddTransient<Transient>();
            services.AddScoped<Scoped>();
            
            services.AddTransient<IDiTransient, Transient>();
            services.AddSingleton<IDiSingleton, Singleton>();
            services.AddScoped<IDiScoped, Scoped>();



            services.AddDatabaseDeveloperPageExceptionFilter();
            
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication()
                .AddCookie(options =>
                {
                    options.SlidingExpiration = true;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            
            services
                .AddIdentity<AppUser,AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddDefaultUI()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            services.AddControllersWithViews();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll", builder=>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
            services.AddAutoMapper(
                typeof(DAL.App.DTO.MappingProfiles.MapperProfile),
                typeof(BLL.App.DTO.MappingProfiles.MapperProfile)
                );
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            SetupAppData(app, Configuration);
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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant()
                        );
                }
            });
            app.UseStaticFiles();

            app.UseCors("CorsAllowAll");

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();
        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

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
                using var userManager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();
                using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<AppRole>>();
                if (userManager != null || roleManager != null)
                {
                    DataInit.SeedIdentity(userManager!, roleManager!);
                }
                else
                {
                    Console.WriteLine("No manager");
                }
            }
            if (configuration.GetValue<bool>("AppData:SeedData"))
            {
                Console.Write("Seed database");
                DataInit.SeedAppData(ctx);
                Console.WriteLine(" - done");
            }


            //C# will dispose all the usings here
        }

    }
}