(function () {
    var picker;
    picker = angular.module('datetimepicker', []);

    picker.constant('dateTimePickerConfig', {
        autoclose: true,
        format: 'yyyy-mm-dd',
        minView: 'month'
    });

    picker.directive('datetimepicker', ['$timeout', 'dateTimePickerConfig', function ($timeout, dateTimePickerConfig) {
        return {
            restrict: 'A',
            require: 'ngModel',
            scope: {
                startDate: '=min',
                endDate: '=max',
                model: '=ngModel',
                opts: '=options',
                value: '='
            },
            link: function ($scope, element, attrs, modelCtrl) {
                var customOpts, el, opts, _formatted, _init, _picker, _setStartDate, _setEndDate, _validateManx, _validateMin;
                el = $(element);
                customOpts = $scope.opts;
                opts = angular.extend({}, dateTimePickerConfig, customOpts);

                modelCtrl.$siEmpty = function (val) {
                    return !val || val.value === null;
                };
                modelCtrl.$render = function () {
                    if (!modelCtrl.$modelValue) {
                        return el.val('');
                    }
                    if (modelCtrl.$modelValue.value === null) {
                        return el.val('');
                    }
                    return el.val(_formatted(modelCtrl.$modelValue));
                };

                _picker = null;
                _setStartDate = function (newValue) {
                    return $timeout(function () {
                        var m;
                        if (_picker) {
                            m = moment(newValue);
                            if (_picker.endDate < m) {
                                _picker.setEndDate(m.format("YYYY-MM-DD"));
                            }
                            return _picker.setStartDate(m.format("YYYY-MM-DD"));
                        }
                    });
                };
                _setEndDate = function (newValue) {
                    return $timeout(function () {
                        var m;
                        if (_picker) {
                            m = moment(newValue);
                            if (_picker.startDate > m) {
                                _picker.setStartDate(m.format("YYYY-MM-DD"));
                            }
                            return _picker.setEndDate(m.format("YYYY-MM-DD"));
                        }
                    });
                }

                _validateMin = function (min, time) {
                    var valid;
                    min = moment(min);
                    time = moment(time);
                    valid = min.isBefore(time) || time.isSame(min, 'day');
                    modelCtrl.$setValidity('min', valid);
                    return valid;
                };
                _validateMax = function (max, time) {
                    var valid;
                    max = moment(max);
                    time = moment(time);
                    valid = max.isAfter(time) || time.isSame(max, 'day');
                    modelCtrl.$setValidity('max', valid);
                    return valid;
                };
                _formatted = function (viewVal) {
                    var f;
                    f = function (date) {
                        if (!moment.isMoment(date)) {
                            return moment(date).format(opts.format);
                        }
                        return date.format(opts.format);
                    }
                },
                _init = function () {
                    var callbackFunction, eventType, _ref;
                    el.datetimepicker(opts);
                    $scope.$watch('value', function (date) {
                        return modelCtrl.$setViewValue({
                            value: $scope.value
                        });
                    });
                    _picker = el.data('datetimepicker');
                    _ref = opts.eventHandlers;
                    for (eventType in _ref) {
                        callbackFunction = _ref[eventType];
                        el.on(eventType, callbackFunction);
                    }
                    modelCtrl.$render();
                }

                _init();

                el.change(function () {
                    if ($.trim(el.val()) === "") {
                        return $timeout(function () {
                            return modelCtrl.$setViewValue({
                                value: null
                            });
                        });
                    }
                });

                if (attrs.min) {
                    $scope.$watch('startDate', function (date) {
                        if (date) {
                            if (!modelCtrl.$isEmpty(modelCtrl.$modelValue)) {
                                _validateMin(date, modelCtrl.$modelValue.value);
                            }
                            opts['startDate'] = moment(date);
                            _setStartDate(moment(date));
                        }
                        else {
                            opts['startDate'] = false;
                        }
                        return _init();
                    });
                }

                if (attrs.max) {
                    $scope.$watch('endDate', function (date) {
                        if (date) {
                            if (!modelCtrl.$isEmpty(modelCtrl.$modelValue)) {
                                _validateMax(date, modelCtrl.$modelValue.value);
                            }
                            opts['endDate'] = moment(date);
                            _setEndDate(moment(date));
                        }
                        else {
                            opts['endDate'] = false;
                        }
                        return _init();
                    });
                }

                if (attrs.options) {
                    $scope.$watch('opts', function (newOpts) {
                        opts = angular.extend(opts, newOpts);
                        return _init();
                    });
                }

                return $scope.$on('$destroy', function () {
                    return _picker != null ? _picker.remove() : void 0;
                });
            }
        };
    }]);
}).call(this);