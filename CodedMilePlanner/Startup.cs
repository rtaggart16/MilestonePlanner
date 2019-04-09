using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodedMilePlanner.Database;
using CodedMilePlanner.Models;
using CodedMilePlanner.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodedMilePlanner
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
            services.AddMvc();

            services.AddDbContext<MilestoneDb>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MilestoneDb>()
                .AddDefaultTokenProviders();

            //Identity Password Rules
            services.Configure<IdentityOptions>(o =>
            {
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = true;
                o.Password.RequireDigit = true;
                o.Password.RequiredLength = 8;
            });

            services.AddTransient<ICodedMileCookieCutter, CodedMileCookieCutter>();
            services.AddTransient<ICodedMileServiceHelper, CodedMileServiceHelper>();
            services.AddTransient<IHelper, Helper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();

                try
                {
                    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())

                    {
                        var db = serviceScope.ServiceProvider.GetService<MilestoneDb>();

                        db.Database.Migrate();//run migrations
                        db.SeedRoles(roleManager);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("Exception: " + e.Message);
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
