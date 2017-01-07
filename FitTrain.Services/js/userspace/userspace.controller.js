'use strict';
angular.module('fitTraining.userspace.controller', [])
    .controller('UserspaceController', [
        '$scope',
        'UserSettingsService',
        function ($scope, userSettingsService) {
            $scope.vm = {
                message: ''
            };
            $scope.model = {
                lastSetting: null,
                mode: 2,
                settings: null
            };

            $scope.$watch('model.mode', function (o, n) {
                userSettingsService.getDietDayByMode($scope.model.mode).then(
                function (response) { $scope.model.settings = response.data },
                function (error) { $scope.vm.message = error.data; });
            });
        }
    ])
    .controller('NewUserSpace', [
        '$scope',
        '$location',
        'UserSettingsService',
        function ($scope, $location, userSettingsService) {
            $scope.vm = {
                message: '',
                activityList: [
                    { id: 0, value: 'Минимальный уровень' },
                    { id: 1, value: 'Тренировки средней тяжести - 3 раз в неделю' },
                    { id: 2, value: 'Тренировки средней тяжести - 5 раз в неделю' },
                    { id: 3, value: 'Интенсивные тренировки 5 раз в неделю' },
                    { id: 4, value: 'Тренировки каждый день' },
                    { id: 5, value: 'Интенсивные тренировки каждый день или по 2 раз в день' },
                    { id: 6, value: 'Ежедневная нагрузка + физическая работа' }
                ]
            };

            $scope.space = {
                weight: 0.0,
                height: 0.00,
                activity: $scope.vm.activityList[0]
            };

            $scope.vm.addSettings = function () {
                userSettingsService.postSettins($scope.space.weight, $scope.space.height, $scope.space.activity).then(
                    function (response) { $location.path('/') },
                    function (error) { $scope.vm.message = error.data; });
            }
        }
    ]);