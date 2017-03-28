using System.Web.Mvc;

namespace Localink.Platform.Web.Controllers
{
    public class AboutController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}