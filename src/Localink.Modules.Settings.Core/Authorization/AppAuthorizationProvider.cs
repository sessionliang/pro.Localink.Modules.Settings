using Abp.Authorization;
using Abp.Localization;

namespace Localink.Modules.Settings.Core.Authorization
{
    /// <summary>
    /// 初始化權限
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var doorSystem = context.GetPermissionOrNull(AppPermissions.Pages_DoorSystem) ?? context.CreatePermission(AppPermissions.Pages_DoorSystem, L("DoorSystem"));

            doorSystem.CreateChildPermission(AppPermissions.Pages_DoorSystem_Settings, L("Settings"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SettingsModuleConsts.LocalizationSourceName);
        }
    }
}
