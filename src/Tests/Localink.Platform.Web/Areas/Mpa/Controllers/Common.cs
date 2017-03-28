using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Web.Areas.Mpa.Models.Common.Modals;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize]
    public class CommonController : AbpZeroTemplateControllerBase
    {
        public PartialViewResult LookupModal(LookupModalViewModel model)
        {
            return PartialView("Modals/_LookupModal", model);
        }
    }
}