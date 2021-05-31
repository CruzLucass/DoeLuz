using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoeLuz.Models;

namespace DoeLuz
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:DoeLuz:ConnectionString"]));
            services.AddTransient<IAdminRepositorio, EFAdminRepositorio>();
            services.AddTransient<IDoadorRepositorio, EFDoadorRepositorio>();
            services.AddTransient<IBeneficiarioRepositorio, EFBeneficiarioRepositorio>();
            services.AddTransient<IDoacaoRepositorio, EFDoacaoRepositorio>();
            services.AddMvc();
            services.AddControllersWithViews();

            //configuração da session
            services.AddSession(options =>
            {
                options.Cookie.Name = ".Aula.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.IsEssential = true;
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SessionControler}/{action=Main}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
