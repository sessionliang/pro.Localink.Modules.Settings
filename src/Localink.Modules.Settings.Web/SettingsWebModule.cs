using System.Reflection;
using Abp.Modules;
using Abp.Resources.Embedded;
using Localink.Modules.Settings.EntityFramework;
using Abp.Web.Mvc;
using Abp.Application.Services;
using Abp.WebApi;
using Abp.Configuration.Startup;
using System.Web.Optimization;
using Localink.Modules.Settings.Web.Navigation;
using Localink.Modules.Settings.Web.App.Startup;
using Localink.Modules.Settings.Application;
using Localink.Modules.Settings.Core;
using System.Web;
using Abp.IO;

namespace Localink.Modules.Settings.Web
{
    [DependsOn(typeof(AbpWebMvcModule), typeof(AbpWebApiModule), typeof(SettingsApplicationModule), typeof(SettingsEntityFrameworkModule))]
    public class SettingsWebModule : AbpModule
    {
        public override void PreInitialize()
        {

            Configuration.Navigation.Providers.Add<SettingsNavigationProvider>();

            Configuration.EmbeddedResources.Sources.Add(
                new EmbeddedResourceSet(
                    "/App/",
                    Assembly.GetExecutingAssembly(),
                    "Localink.Modules.Settings.Web.App"
                )
            );

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                 .ForAll<IApplicationService>(Assembly.GetAssembly(typeof(SettingsApplicationModule)), "app")
                 .Build();

            AppBundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override void PostInitialize()
        {
            var server = HttpContext.Current.Server;
            var appFolders = IocManager.Resolve<AppFolders>();

            

            //創建預設文件夾
            try
            {

            }
            catch { }
        }
    }
}
