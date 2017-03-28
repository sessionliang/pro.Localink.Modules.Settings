using Abp.AutoMapper;
using Localink.Platform.Authorization.Users;
using Localink.Platform.Authorization.Users.Dto;
using Localink.Platform.Web.Areas.Mpa.Models.Common;

namespace Localink.Platform.Web.Areas.Mpa.Models.Users
{
    [AutoMapFrom(typeof(GetUserPermissionsForEditOutput))]
    public class UserPermissionsEditViewModel : GetUserPermissionsForEditOutput, IPermissionsEditViewModel
    {
        public User User { get; private set; }

        public UserPermissionsEditViewModel(GetUserPermissionsForEditOutput output, User user)
        {
            User = user;
            output.MapTo(this);
        }
    }
}