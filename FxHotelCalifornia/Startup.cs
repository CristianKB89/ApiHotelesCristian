using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FxHotelCalifornia.Models;
using FxHotelCalifornia.Interfaces;
using FxHotelCalifornia.Services;
using Microsoft.Extensions.Options;

namespace FxHotelCalifornia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configuración de PtSettings y DbServices y EmailService
            services.AddSingleton<DbServices>();
            services.AddSingleton<EmailSender>();

            services.Configure<PtSettings>(Configuration.GetSection(nameof(PtSettings)));
            services.AddSingleton<IPtSettings>(d => d.GetRequiredService<IOptions<PtSettings>>().Value);
            services.Configure<EmailSettings>(Configuration.GetSection(nameof(EmailSettings)));
            services.AddSingleton<IEmailSettings>(d => d.GetRequiredService<IOptions<EmailSettings>>().Value);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Configura el manejo de errores para entorno de producción
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
