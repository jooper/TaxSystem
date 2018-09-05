using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Tax.CompanyModuleService.Uinities
{
    public  class ConfigurtaionServices
    {
        public static IConfiguration Configuration { get; set; }

        static ConfigurtaionServices()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载  
            //AppConfigurtaionServices.Configuration["ServiceUrl"];
            //AppConfigurtaionServices.Configuration["Appsettings:SystemName"];
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource {Path = "surgingSettings.json", ReloadOnChange = true})
                .Build();
        }
    }
}