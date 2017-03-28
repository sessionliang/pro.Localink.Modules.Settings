using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Localink.Modules.Settings.Application.Tests.Dto;
using System.Threading.Tasks;

namespace Localink.Modules.Settings.Application
{
    /// <summary>
    /// 任务领域服务
    /// </summary>
    public interface ITestAppService : IApplicationService
    {
        /// <summary>
        /// 任务列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetTestDto>> GetTests(GetTestInput input);

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TestDto> CreateTest(CreateTestInput input);

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TestDto> UpdateTest(UpdateTestInput input);

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteTest(NullableIdDto<long> input);
    }
}
