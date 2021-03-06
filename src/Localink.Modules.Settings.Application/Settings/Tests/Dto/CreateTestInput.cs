using Abp.AutoMapper;
using Localink.Modules.Settings.Core;
using System.ComponentModel.DataAnnotations;

namespace Localink.Modules.Settings.Application.Tests.Dto
{
    [AutoMapFrom(typeof(Test))]
    public class CreateTestInput 
    {
        /// <summary>
        /// 任务
        /// </summary>
        [Required]
        [StringLength(Test.MaxTaskLength)]
        public string Task { get; set; }
       
    }
}
