using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class WelcomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}