using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Organizations;
using Abp.Web.Mvc.Authorization;
using Localink.Platform.Authorization;
using Localink.Platform.Web.Areas.Mpa.Models.OrganizationUnits;
using Localink.Platform.Web.Controllers;

namespace Localink.Platform.Web.Areas.Mpa.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_OrganizationUnits)]
    public class OrganizationUnitsController : AbpZeroTemplateControllerBase
    {
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;

        public OrganizationUnitsController(IRepository<OrganizationUnit, long> organizationUnitRepository)
        {
            _organizationUnitRepository = organizationUnitRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public PartialViewResult CreateModal(long? parentId)
        {
            return PartialView("_CreateModal", new CreateOrganizationUnitModalViewModel(parentId));
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree)]
        public async Task<PartialViewResult> EditModal(long id)
        {
            var organizationUnit = await _organizationUnitRepository.GetAsync(id);
            var model = organizationUnit.MapTo<EditOrganizationUnitModalViewModel>();

            return PartialView("_EditModal", model);
        }
    }
}