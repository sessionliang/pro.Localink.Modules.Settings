using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Localink.Modules.Settings.Core;

namespace Localink.Modules.Settings.Application.Tests.Dto
{
    /// <summary>
    /// 内容传输对象
    /// </summary>
    [AutoMapFrom(typeof(Test))]
    public class TestDto : AuditedEntityDto<long>
    {
        /// <summary>
        /// 任务
        /// </summary>
        public string Task { get; set; }
        
    }
}
