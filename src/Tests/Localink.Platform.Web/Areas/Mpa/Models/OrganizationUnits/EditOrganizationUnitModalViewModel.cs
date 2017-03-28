using Abp.AutoMapper;
using Abp.Organizations;

namespace Localink.Platform.Web.Areas.Mpa.Models.OrganizationUnits
{
    [AutoMapFrom(typeof(OrganizationUnit))]
    public class EditOrganizationUnitModalViewModel
    {
        public long? Id { get; set; }

        public string DisplayName { get; set; }
    }
}