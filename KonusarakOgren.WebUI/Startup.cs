using KonusarakOgren.Business.Abstract;
using KonusarakOgren.Business.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KonusarakOgren.Entity;
using KonusarakOgren.Entity.Abstract;
using KonusarakOgren.Entity.Concrete;
using KonusarakOgren.Service.Abstract;
using KonusarakOgren.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KonusarakOgren.WebUI
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
            services.AddDbContext<KonusarakOgrenContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("SqliteConnection"), x=> x.MigrationsAssembly("KonusarakOgren.WebUI")));

            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 0;
            options.Password.RequiredUniqueChars = 0;
        })
                .AddEntityFrameworkStores<KonusarakOgrenContext>()
                .AddDefaultTokenProviders();

            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
                opt => { opt.LoginPath = "/Auth/Login"; });

            services.AddTransient<IAuthBusiness, AuthBusiness>();
            services.AddTransient<IExamBusiness, ExamBusiness>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericDal<>));
            services.AddTransient<IExamService, ExamService>();
            services.AddTransient<IAuthService, AuthService>();
            
            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Exam}/{action=ExamGenerator}/{id?}");
            });
        }
    }
}
