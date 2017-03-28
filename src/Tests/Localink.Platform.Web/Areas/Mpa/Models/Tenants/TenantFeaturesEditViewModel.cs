using Abp.AutoMapper;
using Localink.Platform.MultiTenancy;
using Localink.Platform.MultiTenancy.Dto;
using Localink.Platform.Web.Areas.Mpa.Models.Common;

namespace Localink.Platform.Web.Areas.Mpa.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesForEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesForEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }

        public TenantFeaturesEditViewModel(Tenant tenant, GetTenantFeaturesForEditOutput output)
        {
            Tenant = tenant;
            output.MapTo(this);
        }
    }
}