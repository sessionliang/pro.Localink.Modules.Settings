using System.ComponentModel.DataAnnotations;
using Abp.Runtime.Validation;
using Localink.Modules.CMS.Dto;

namespace Localink.Modules.Settings.Application.Tests.Dto
{
    public class GetTestInput : PagedAndSortedInputDto, IShouldNormalize
    {

        public string Task { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime";
            }
        }
    }
}