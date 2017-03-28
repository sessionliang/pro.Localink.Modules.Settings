using System.Collections.Generic;
using Localink.Platform.Caching.Dto;

namespace Localink.Platform.Web.Areas.Mpa.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}