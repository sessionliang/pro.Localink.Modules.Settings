using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Localink.Platform.Configuration.Tenants.Dto;

namespace Localink.Platform.Web.Areas.Mpa.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}