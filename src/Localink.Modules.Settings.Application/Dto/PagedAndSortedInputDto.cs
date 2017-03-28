using Abp.Application.Services.Dto;
using Localink.Modules.Settings.Application;

namespace Localink.Modules.CMS.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}