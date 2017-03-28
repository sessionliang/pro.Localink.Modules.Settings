using Abp.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localink.Modules.Settings.Core.Authorization
{
    public class Role : AbpRole<User>
    {
        public Role()
        {

        }
    }
}
