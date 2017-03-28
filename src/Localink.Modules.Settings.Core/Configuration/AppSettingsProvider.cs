using Abp.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localink.Modules.Settings.Core.Configuration
{
    public class AppSettingsProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            //Tenant Settings

            return new SettingDefinition[] {
                
            };
        }
    }
}
