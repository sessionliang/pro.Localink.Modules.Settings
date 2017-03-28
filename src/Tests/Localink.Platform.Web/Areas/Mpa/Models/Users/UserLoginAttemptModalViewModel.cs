using System.Collections.Generic;
using Localink.Platform.Authorization.Users.Dto;

namespace Localink.Platform.Web.Areas.Mpa.Models.Users
{
    public class UserLoginAttemptModalViewModel
    {
        public List<UserLoginAttemptDto> LoginAttempts { get; set; }
    }
}