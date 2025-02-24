using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace NimapProjectUsingADO.net.Models
{
    public class ConfigureServices(IServiceCollection Services)
    {
        Services.AddControllersWithViews();
             services.AddScoped<ICategoryyService, CategoryyCrud>();
            services.AddScoped<CategoryService> () ;

    }
}
