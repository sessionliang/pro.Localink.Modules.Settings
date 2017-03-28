using System.Web.Mvc;

namespace Localink.Platform.Web.Controllers
{
    public class HomeController : AbpZeroTemplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}