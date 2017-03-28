using Abp.Application.Navigation;
using Abp.Localization;
using Localink.Modules.Settings.Core;
using Localink.Modules.Settings.Core.Authorization;

namespace Localink.Modules.Settings.Web.Navigation
{
    public class SettingsNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu.AddItem(
                new MenuItemDefinition(
                    SettingsAppPageNames.Test.TestName,
                    L("Settings"),
                    icon: "fa fa-settings",
                    url: "settings",
                    requiresAuthentication: true
                ).AddItem(new MenuItemDefinition(
                        SettingsAppPageNames.Test.TestMenu,
                        L("Tests"),
                        url: "settings.tests",
                        icon: "icon-manage",
                        requiredPermissionName: AppPermissions.Pages_DoorSystem_Settings
                        )
                   )
            );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SettingsModuleConsts.LocalizationSourceName);
        }
    }
}
