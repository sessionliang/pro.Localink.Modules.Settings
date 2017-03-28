using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Authorization;
using Localink.Platform.Caching;
using Localink.Platform.Web.Areas.Mpa.Models.Maintenance;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Maintenance)]
    public class MaintenanceController : AbpZeroTemplateControllerBase
    {
        private readonly ICachingAppService _cachingAppService;

        public MaintenanceController(ICachingAppService cachingAppService)
        {
            _cachingAppService = cachingAppService;
        }

        public ActionResult Index()
        {
            var model = new MaintenanceViewModel
            {
                Caches = _cachingAppService.GetAllCaches().Items
            };

            return View(model);
        }
    }
}