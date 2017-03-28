using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Localink.Modules.Settings.Core;
using Abp.Zero.EntityFramework;

namespace Localink.Modules.Settings.EntityFramework
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(SettingsCoreModule))]
    public class SettingsEntityFrameworkModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SettingsDbContext>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
