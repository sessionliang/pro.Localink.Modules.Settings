using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Authorization;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Tenant_Dashboard)]
    public class DashboardController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}