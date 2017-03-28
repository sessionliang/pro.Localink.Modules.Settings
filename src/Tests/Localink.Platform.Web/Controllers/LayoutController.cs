using System.Web.Mvc;
using Abp.Application.Navigation;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Threading;
using Localink.Platform.Configuration;
using Localink.Platform.Sessions;
using Localink.Platform.Web.Models.Layout;
using Localink.Platform.Web.Navigation;

namespace Localink.Platform.Web.Controllers
{
    /// <summary>
    /// Layout for 'front end' pages.
    /// </summary>
    public class LayoutController : AbpZeroTemplateControllerBase
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IUserNavigationManager _userNavigationManager;
        private readonly IMultiTenancyConfig _multiTenancyConfig;
        private readonly ILanguageManager _languageManager;

        public LayoutController(
            ISessionAppService sessionAppService, 
            IUserNavigationManager userNavigationManager, 
            IMultiTenancyConfig multiTenancyConfig,
            ILanguageManager languageManager)
        {
            _sessionAppService = sessionAppService;
            _userNavigationManager = userNavigationManager;
            _multiTenancyConfig = multiTenancyConfig;
            _languageManager = languageManager;
        }

        [ChildActionOnly]
        public PartialViewResult Header(string currentPageName = "")
        {
            var headerModel = new HeaderViewModel();
            
            if (AbpSession.UserId.HasValue)
            {
                headerModel.LoginInformations = AsyncHelper.RunSync(() => _sessionAppService.GetCurrentLoginInformations());
            }

            headerModel.Languages = _languageManager.GetLanguages();
            headerModel.CurrentLanguage = _languageManager.CurrentLanguage;
            
            headerModel.Menu = AsyncHelper.RunSync(() => _userNavigationManager.GetMenuAsync(FrontEndNavigationProvider.MenuName, AbpSession.ToUserIdentifier()));
            headerModel.CurrentPageName = currentPageName;

            headerModel.IsMultiTenancyEnabled = _multiTenancyConfig.IsEnabled;
            headerModel.TenantRegistrationEnabled = SettingManager.GetSettingValue<bool>(AppSettings.TenantManagement.AllowSelfRegistration);

            return PartialView("~/Views/Layout/_Header.cshtml", headerModel);
        }
    }
}