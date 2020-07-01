using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebNetCoreDataLib.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebNetCoreDataLib.Models;
using WebNetCoreDataLib.WNCCommonHelper;
using NetDataLibrary.Db;
using WebNetCoreDataLib.Claims;
using NetDataLibrary.Data;

namespace WebNetCoreDataLib
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
            services.AddTransient<IPasswordHasher<ApplicationUser>, WNCPasswordHasher>(); // Custom Password Hasher Implementation
            
            services.AddDistributedMemoryCache(); // for session feature

            services.AddSession(sessionOptions =>                     //add session feature
            {
                sessionOptions.Cookie.Name = ".AVR.Session";
                // Set a short timeout for easy testing.
                sessionOptions.IdleTimeout = TimeSpan.FromSeconds(10);
                sessionOptions.Cookie.HttpOnly = true;
                // Make the session cookie essential
                sessionOptions.Cookie.IsEssential = true;
            });
            //configure Data library -- start
            services.AddSingleton(new ConnectionStringData
            {
                SqlConnectionName = "Admin"
            });

            services.AddSingleton<IDataAccess, SqlDb>();
            services.AddSingleton<IAccountData, AccountData>();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            
            //Important
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            //Important
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, WNCClaimsPrincipalFactory>();
            
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
    }
}
