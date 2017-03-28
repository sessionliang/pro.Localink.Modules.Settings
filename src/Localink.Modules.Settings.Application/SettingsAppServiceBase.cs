using Abp.Application.Services;
using Abp.Runtime.Session;
using Localink.Modules.Settings.Core;
using Localink.Modules.Settings.Core.Authorization;
using Localink.Modules.Settings.Core.MultiTenancy;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Abp.MultiTenancy;
using Abp.IdentityFramework;

namespace Localink.Modules.Settings.Application
{
    public abstract class SettingsAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        public RoleManager RoleManager { get; set; }

        protected SettingsAppServiceBase()
        {
            LocalizationSourceName = SettingsModuleConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual User GetCurrentUser()
        {
            var user = UserManager.FindById(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual Tenant GetCurrentTenant()
        {
            return TenantManager.GetById(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
