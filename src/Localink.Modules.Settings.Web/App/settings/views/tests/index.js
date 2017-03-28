(function () {

    appModule.controller('settings.views.tests.index', [
        '$scope', '$uibModal', 'uiGridConstants', 'abp.services.app.test', 'appSession',
        function ($scope, $uibModal, uiGridConstants, testService, $appSession) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                App.initAjax();
            });

            vm.loading = false;

            vm.permissions = {
                manageTests: abp.auth.hasPermission('Pages.DoorSystem.Settings'),
                createTests: abp.auth.hasPermission('Pages.DoorSystem.Settings'),
                editTests: abp.auth.hasPermission('Pages.DoorSystem.Settings'),
                deleteTests: abp.auth.hasPermission('Pages.DoorSystem.Settings')
            };

            vm.requestParams = {
                type: '',
                skipCount: 0,
                maxResultCount: app.consts.grid.defaultPageSize,
                sorting: null
            };

            vm.gridOptions = {
                enableHorizontalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                enableVerticalScrollbar: uiGridConstants.scrollbars.WHEN_NEEDED,
                paginationPageSizes: app.consts.grid.defaultPageSizes,
                paginationPageSize: app.consts.grid.defaultPageSize,
                useExternalPagination: true,
                useExternalSorting: true,
                appScopeProvider: vm,
                columnDefs: [
                    {
                        name: 'Actions',
                        enableSorting: false,
                        width: 150,
                        headerCellTest: '<span></span>',
                        cellTest:
                                '<div class=\"ui-grid-cell-contents\">' +
                                '  <div class="btn-group dropdown" uib-dropdown="">' +
                                '    <button class="btn btn-xs btn-primary blue" uib-dropdown-toggle="" aria-haspopup="true" aria-expanded="false"><i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span></button>' +
                                '    <ul uib-dropdown-menu>' +
                                '      <li><a ng-if="grid.appScope.permissions.editTests" ng-click="grid.appScope.editTest(row.entity)">' + app.localize('Edit') + '</a></li>' +
                                '      <li><a ng-if="grid.appScope.permissions.deleteTests" ng-click="grid.appScope.remove(row.entity)" >' + app.localize('Delete') + '</a></li>' +
                                '      <li><a ng-click="grid.appScope.showDetails(row.entity)">' + app.localize('Detail') + '</a></li>' +
                                '    </ul>' +
                                '  </div>' +
                                '</div>'
                    }
                    ,
                    {
                        name: app.localize('Task'),
                        field: 'task',
                        cellTest:
                                '<div class=\"ui-grid-cell-contents\" title="{{row.entity.task}}"> {{COL_FIELD CUSTOM_FILTERS}} &nbsp;</div>',
                        width: 150
                    }
                ],
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (!sortColumns || !sortColumns.length || !sortColumns[0].field) {
                            vm.requestParams.sorting = null;
                        } else {
                            vm.requestParams.sorting = sortColumns[0].field + ' ' + sortColumns[0].sort.direction;
                        }

                        vm.getTests();
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (pageNumber, pageSize) {
                        vm.requestParams.skipCount = (pageNumber - 1) * pageSize;
                        vm.requestParams.maxResultCount = pageSize;

                        vm.getTests();
                    });
                },
                data: []
            };

            vm.getTests = function () {
                vm.loading = true;
                testService.getTests($.extend({}, vm.requestParams))
                    .then(function (result) {
                        vm.gridOptions.totalItems = result.data.totalCount;
                        vm.gridOptions.data = result.data.items;
                    }).finally(function () {
                        vm.loading = false;
                    });
            };

            vm.exportToExcel = function () {
                testService.getTestsToExcel(vm.requestParams)
                    .then(function (result) {
                        app.downloadTempFile(result);
                    });
            };

            vm.showDetails = function (test) {
                $uibModal.open({
                    templateUrl: '~/App/settings/views/tests/detailModal.cshtml',
                    controller: 'settings.views.tests.detailModal as vm',
                    backdrop: 'static',
                    resolve: {
                        test: function () {
                            return test;
                        }
                    }
                });
            };

            vm.remove = function (test) {
                abp.message.confirm(
                    app.localize('RemoveTestWarningMessage', test.title),
                    function (isConfirmed) {
                        if (isConfirmed) {
                            testService.deleteTest({
                                id: test.id
                            }).then(function () {
                                vm.getTests();
                            });
                        }
                    });
            };

            vm.editTest = function (test) {
                vm.openCreateOrEditTestModal(test, function (newTest) {
                    vm.getTests();
                })
            };

            vm.addTest = function (test) {
                vm.openCreateOrEditTestModal(test, function (newTest) {
                    vm.gridOptions.totalItems++;
                    vm.gridOptions.data.push(newTest);
                })
            };

            vm.openCreateOrEditTestModal = function (test, closeCallback) {
                var modalInstance = $uibModal.open({
                    templateUrl: '~/App/settings/views/tests/createOrEditTestModal.cshtml',
                    controller: 'settings.views.tests.createOrEditTestModal as vm',
                    backdrop: 'static',
                    size: "lg",
                    resolve: {
                        test: function () {
                            return test;
                        }
                    }
                });

                modalInstance.result.then(function (result) {
                    closeCallback && closeCallback(result);
                });
            };

            vm.getTests();
        }
    ]);
})();