using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Core.EF.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core.EF.EntityFrameworkCore.Repositories;
using Core.Services.Domain.Repositories;
using SisWeb.Components;
using SisWeb.EF.Models;
using SisWeb.Services;

namespace SisWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddNewtonsoftJson();

            // EF Context
            services.AddDbContext<AppDbContext, SISContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:Default"]));

            services.AddBootstrapProviders();
            services.AddFontAwesomeIcons();
            services.AddTransient(typeof(IRepository<Uzivatele, int>), typeof(EfCoreRepositoryBase<Uzivatele, int>));
            services.AddApplicationServices();
            services.AddKendoBlazor();
            services.AddRazorComponents();
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
                app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting(routes =>
            {
                routes.MapRazorPages();
                routes.MapComponentHub<App>("app");
            });
        }
    }
}
