using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using Localink.Modules.Settings.Core;
using Localink.Modules.Settings.Core.MultiTenancy;
using Localink.Modules.Settings.Core.Authorization;
using Abp.Zero.EntityFramework;

namespace Localink.Modules.Settings.EntityFramework
{
    //[DbConfigurationType(typeof(TodoModuleDbConfiguration))]
    public class SettingsDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /// <summary>
        /// 测试
        /// </summary>
        public virtual IDbSet<Test> Tests { get; set; }

        

        /* Default constructor is needed for EF command line tool. */
        public SettingsDbContext()
            : base("Default")
        {

        }

        /* This constructor is used by ABP to pass connection string.
         * Notice that, actually you will not directly create an instance of ModularTodoAppDbContext since ABP automatically handles it.
         */
        public SettingsDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection. */
        public SettingsDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }

        public SettingsDbContext(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {

        }
    }

    //public class TodoModuleDbConfiguration : DbConfiguration
    //{
    //    public TodoModuleDbConfiguration()
    //    {
    //        SetProviderServices(
    //            "System.Data.SqlClient",
    //            System.Data.Entity.SqlServer.SqlProviderServices.Instance
    //        );
    //    }
    //}
}
