'use strict';
//UserspaceController

angular.module('fitTraining.userspace.controller', [])
.controller('UserspaceController', [
    '$scope',
    function ($scope) {
        
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

        $scope.vm.addSettings = function() {
            userSettingsService.postSettins($scope.space.weight, $scope.space.height, $scope.space.activity).then(
                function (request) { $location.path('/') },
                function (error) { $scope.vm.message = error.data; });
        }
    }
])