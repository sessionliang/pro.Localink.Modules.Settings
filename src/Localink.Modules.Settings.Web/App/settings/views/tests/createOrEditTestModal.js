(function () {
    appModule.controller('settings.views.tests.createOrEditTestModal', ['$scope', '$uibModalInstance', 'abp.services.app.test', 'test',
    function ($scope, $uibModalInstance, testService, test) {
        var vm = this;
        vm.test = test;
        vm.saving = false;

        //获取模板的内容
        if (vm.test && vm.test.id) {
            testService.getTest({ id: test.id })
            .then(function (result) {
                vm.test = result;
            });
        }

        vm.save = function () {
            if (vm.test && vm.test.id) {
                testService.updateTest(vm.test)
                .then(function (result) {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close(result);
                });
            }
            else {
                testService.createTest(vm.test)
                .then(function (result) {
                    abp.notify.info(app.localize('SavedSuccessfully'));
                    $uibModalInstance.close(result);
                });
            }
        };

        vm.cancel = function () {
            $uibModalInstance.dismiss();
        };

    }]);
})();