using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using Localink.Modules.Settings.Core.Authorization;


namespace Localink.Modules.Settings.Core.MultiTenancy
{
    /// <summary>
    /// Tenant manager.
    /// </summary>
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository,
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
            AbpEditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore)
            : base(
                  tenantRepository,
                  tenantFeatureRepository,
                  editionManager,
                  featureValueStore)
        {
        }

    }
}
