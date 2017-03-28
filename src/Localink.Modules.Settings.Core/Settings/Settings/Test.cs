using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Localink.Modules.Settings.Core
{
    /// <summary>
    /// 任务
    /// </summary>
    [Table("doorSystem_Test")]
    public class Test : FullAuditedEntity<long>, IMayHaveTenant
    {
        public const int MaxTaskLength = 50;

        /// <summary>
        /// 租户ID
        /// </summary>
        public virtual int? TenantId { get; set; }

        /// <summary>
        ///  测试任务
        /// </summary>
        [Required]
        [StringLength(MaxTaskLength)]
        public virtual string Task { get; set; }


        /// <summary>
        ///  构造函数<see cref="Test"/>
        /// </summary>
        public Test()
        { }

        /// <summary>
        ///  构造函数<see cref="Test"/>
        /// </summary>
        public Test(string task)
        {
            Task = task;
        }

    }
}
