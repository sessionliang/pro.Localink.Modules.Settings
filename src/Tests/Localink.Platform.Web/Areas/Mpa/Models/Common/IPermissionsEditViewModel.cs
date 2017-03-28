using System.Collections.Generic;
using Localink.Platform.Authorization.Permissions.Dto;

namespace Localink.Platform.Web.Areas.Mpa.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}