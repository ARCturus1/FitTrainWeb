'use strict';
angular.module('fitTraining.training.controller', [])
    .controller('TrainingController', [
        '$scope',
        'TrainingService',
        function ($scope, trainingService) {
            $scope.vm = {
                message: ''
            };
            $scope.model = {
                items: null
                //lastSetting: null,
                //mode: 2,
                //settings: null
            };

            trainingService.getAll().success(function(res) {
                if (res.data != null)
                    $scope.model.items = res;
            }).error(function(err) {
                $scope.vm.message = err;
            });
            //$scope.$watch('model.mode', function (o, n) {
            //    userSettingsService.getDietDayByMode($scope.model.mode).then(
            //    function (response) { $scope.model.settings = response.data },
            //    function (error) { $scope.vm.message = error.data; });
            //});
        }
    ])
    .controller('NewTraining', [
        '$scope',
        '$location',
        'TrainingService',
        function ($scope, $location, trainingService) {
            $scope.vm = {
                message: '',
                currentTraining: null
            };

            trainingService.getCurrent().success(function (res) {
                $scope.vm.currentTraining = res;
            }).error(function (err) {
                $scope.vm.message = err;
            });

            //$scope.space = {
            //    weight: 0.0,
            //    height: 0.00,
            //    activity: $scope.vm.activityList[0]
            //};

            //$scope.vm.addSettings = function () {
            //    userSettingsService.postSettins($scope.space.weight, $scope.space.height, $scope.space.activity).then(
            //        function (response) { $location.path('/') },
            //        function (error) { $scope.vm.message = error.data; });
            //}
        }
    ]);