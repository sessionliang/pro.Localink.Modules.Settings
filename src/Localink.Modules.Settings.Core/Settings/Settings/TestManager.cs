using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.UI;

namespace Localink.Modules.Settings.Core
{
    /// <summary>
    ///  领域逻辑：任务
    /// </summary>
    public class TestManager : DomainService
    {
        /// <summary>
        /// 任务仓储
        /// </summary>
        public IRepository<Test, long> TestRepository { get; private set; }
        

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="testRepository"></param>
        public TestManager(IRepository<Test, long> testRepository)
        {
            TestRepository = testRepository;
            LocalizationSourceName = Localink.Modules.Settings.Core.SettingsModuleConsts.LocalizationSourceName;
        }

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(Test test)
        {
            await ValidateTestAsync(test);
            await TestRepository.InsertAsync(test);
            
        }

        /// <summary>
        ///  获取任务
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Test> GetByIdAsync(long id)
        {
            return await TestRepository.GetAsync(id);
        }

        /// <summary>
        ///  获取任务
        /// </summary>
        /// <returns></returns>
        public virtual Test GetById(long id)
        {
            return TestRepository.Get(id);
        }

        /// <summary>
        ///  获取任务集合
        /// </summary>
        /// <returns></returns>
        public virtual async Task<List<Test>> FindTest()
        {
            return await TestRepository.GetAllListAsync();
        }

        /// <summary>
        ///  校验任务
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        protected virtual async Task ValidateTestAsync(Test test)
        {
            var siblings = (await FindTest())
                                  .Where(a => a.Id != test.Id)
                                  .ToList();
            if (siblings.Any(a => a.Task == "Admin"))
            {
                throw new UserFriendlyException(L("TaskNameCanNotBeAdmin", test.Task));
            }
        }
    }
}
