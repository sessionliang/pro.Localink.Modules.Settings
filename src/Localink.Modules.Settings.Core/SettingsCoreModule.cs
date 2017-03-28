using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Abp.Modules;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Localink.Modules.Settings.Core.Configuration;
using Abp.IO;
using System.Web;
using Localink.Modules.Settings.Core.MultiTenancy;
using Localink.Modules.Settings.Core.Authorization;
using Abp.Zero.Configuration;

namespace Localink.Modules.Settings.Core
{
    public class SettingsCoreModule : AbpModule
    {
        /// <summary>
        /// Current version of the CMS module.
        /// </summary>
        public const string CurrentVersion = "1.0.0.0";

        public override void PreInitialize()
        {
            //Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            //添加本地化資源
            Configuration.Localization.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    SettingsModuleConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        Assembly.GetExecutingAssembly(),
                        "Localink.Modules.Settings.Core.Localization.SettingsModule"
                        )
                    )
                );

            //添加應用程序配置
            Configuration.Settings.Providers.Add<AppSettingsProvider>();
        }

        public override void Initialize()
        {
            //依賴注入
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
