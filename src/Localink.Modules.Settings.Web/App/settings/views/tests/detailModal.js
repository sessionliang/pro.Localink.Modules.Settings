(function () {
    appModule.controller('cms.views.tests.detailModal', [
        '$scope', '$uibModalInstance', 'test', 'abp.services.app.test',
        function ($scope, $uibModalInstance, test, testService) {
            var vm = this;

            vm.test = test;

            //获取模板的内容
            vm.getTest = function () {
                if (vm.test.id) {
                    testService.getTest({ id: test.id })
                    .then(function (result) {
                        vm.test = result;
                    });
                }
            }

            vm.close = function () {
                $uibModalInstance.dismiss();
            };

            vm.getTest();
        }
    ]);
})();