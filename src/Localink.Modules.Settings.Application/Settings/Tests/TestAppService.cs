using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Localink.Modules.Settings.Core;
using System.Data.Entity;
using Abp.Linq.Extensions;
using Localink.Modules.Settings.Application.Tests.Dto;

namespace Localink.Modules.Settings.Application
{
    public class TestAppService : SettingsAppServiceBase, ITestAppService
    {
        private readonly TestManager _testManager;

        public TestAppService(
            TestManager testManager
            )
        {
            _testManager = testManager;
        }

        public async Task<TestDto> CreateTest(CreateTestInput input)
        {

            var test = new Test(input.Task);
            await _testManager.CreateAsync(test);
            await CurrentUnitOfWork.SaveChangesAsync();

            return test.MapTo<TestDto>();
        }

        public async Task DeleteTest(NullableIdDto<long> input)
        {
            await _testManager.TestRepository.DeleteAsync(input.Id.Value);
        }

        public async Task<PagedResultDto<GetTestDto>> GetTests(GetTestInput input)
        {
            var query = from t in _testManager.TestRepository.GetAll()
                        where t.Task.Contains(input.Task)
                        orderby input.Sorting
                        select new { t };
            var totalCount = await query.CountAsync();
            var items = await query.PageBy(input).ToListAsync();
            return new PagedResultDto<GetTestDto>(
                totalCount,
                items.Select(
                item =>
                {
                    var dto = item.t.MapTo<GetTestDto>();
                    return dto;
                }
                ).ToList());

        }


        public async Task<TestDto> UpdateTest(UpdateTestInput input)
        {
            var test = await _testManager.TestRepository.GetAsync(input.Id);
            test.Task = input.Task;
            await _testManager.TestRepository.UpdateAsync(test);

            await CurrentUnitOfWork.SaveChangesAsync();
            return test.MapTo<TestDto>();
        }
    }
}
