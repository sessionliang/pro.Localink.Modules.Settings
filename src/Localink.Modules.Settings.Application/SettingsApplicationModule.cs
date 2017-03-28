using System.Reflection;
using Abp.Modules;
using Localink.Modules.Settings.Core.Authorization;

namespace Localink.Modules.Settings.Application
{
    public class SettingsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
