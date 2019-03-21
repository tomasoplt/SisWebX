using Microsoft.Extensions.DependencyInjection;
using SisWeb.Services.Authentication;
using SisWeb.Services.Session;
using SisWeb.Services.SisCore;

namespace SisWeb.Services
{
    public static class SisWebServicesModule
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IObjectService, ObjectService>();
            services.AddTransient<IPlovakService, PlovakService>();
            services.AddSingleton<ISessionHelper, SessionHelper>();
        }
    }
}
