using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Localink.Platform.Editions.Dto;

namespace Localink.Platform.Web.Areas.Mpa.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}