(function () {

    //路由设置
    angular.module('app').config([
        '$stateProvider',
        function ($stateProvider) {

            $stateProvider.state('settings', {
                'abstract': true,
                url: '/settings',
                template: '<div ui-view class="fade-in-up"></div>'
            });

            if (abp.auth.hasPermission('Pages.DoorSystem.Settings')) {
                $stateProvider.state('settings.tests', {
                    url: '/tests',
                    templateUrl: '~/App/settings/views/tests/index.cshtml',
                    menu: 'Settings.Tests'
                });
            }
        }
    ]);


    //自定义的js文件输出

    window.document.write("<script src='/App/settings/views/tests/index.js'></script>");
    window.document.write("<script src='/App/settings/views/tests/detailModal.js'></script>");
    window.document.write("<script src='/App/settings/views/tests/createOrEditTestModal.js'></script>");

})();