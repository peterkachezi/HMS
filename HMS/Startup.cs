using HMS.Data.Models;
using HMS.Data.Services.AppointmentModule;
using HMS.Data.Services.CountyModule;
using HMS.Data.Services.DepartmentModule;
using HMS.Data.Services.DiseaseModule;
using HMS.Data.Services.HospitalServiceModule;

using HMS.Data.Services.PatientService;
using HMS.Data.Services.SMSModule;
using HMS.Extensions;
using HMS.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS
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
            services.AddMvc().AddRazorRuntimeCompilation();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

                options.UseLazyLoadingProxies();

            }, ServiceLifetime.Transient);

            services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, ApplicationUserClaimsPrincipalFactory>();

            services.AddControllersWithViews();

            services.AddScoped<IPatientService, PatientService>();

            services.AddTransient<ICountyService, CountyService>();


            services.AddTransient<IDiseaseService, DiseaseService>();

            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddTransient<IHospitalService, HospitalService>();

            services.AddTransient<IMessagingService, MessagingService>();

            services.AddTransient<IAppointmentService, AppointmentService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(

            IApplicationBuilder app,

            IWebHostEnvironment env,

            UserManager<AppUser> userManager,

            RoleManager<IdentityRole> roleManager)
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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            SeedUsers.seed(userManager, roleManager);

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                name: "Reception",
                pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }

    }
}
