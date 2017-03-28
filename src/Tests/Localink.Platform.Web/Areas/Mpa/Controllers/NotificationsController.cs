using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Authorization;
using Localink.Platform.Notifications;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class NotificationsController : AbpZeroTemplateControllerBase
    {
        private readonly INotificationAppService _notificationApp;

        public NotificationsController(INotificationAppService notificationApp)
        {
            _notificationApp = notificationApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> SettingsModal()
        {
            var notificationSettings = await _notificationApp.GetNotificationSettings();
            return PartialView("_SettingsModal", notificationSettings);
        }
    }
}