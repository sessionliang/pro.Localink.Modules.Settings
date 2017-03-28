using System.Web.Mvc;
using Abp.Auditing;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Authorization;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [DisableAuditing]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_AuditLogs)]
    public class AuditLogsController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}