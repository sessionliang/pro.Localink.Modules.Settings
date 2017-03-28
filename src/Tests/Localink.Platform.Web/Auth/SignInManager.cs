using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Uow;
using Microsoft.Owin.Security;
using Localink.Platform.Authorization.Roles;
using Localink.Platform.Authorization.Users;
using Localink.Platform.MultiTenancy;

namespace Localink.Platform.Web.Auth
{
    public class SignInManager : AbpSignInManager<Tenant, Role, User>
    {
        public SignInManager(
            UserManager userManager, 
            IAuthenticationManager authenticationManager, 
            ISettingManager settingManager,
            IUnitOfWorkManager unitOfWorkManager) 
            : base(
                  userManager, 
                  authenticationManager,
                  settingManager,
                  unitOfWorkManager)
        {
        }
    }
}