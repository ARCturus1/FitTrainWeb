'use strict';
angular.module('fitTraining.training.controller', [])
    .controller('TrainingController', [
        '$scope',
        'TrainingService',
        function($scope, trainingService) {
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
        'ExecicesService',
        function($scope, $location, trainingService, execicesService) {
            $scope.vm = {
                message: '',
                currentTraining: null
            };
            $scope.model = { execices: [] };

            $scope.vm.addExe = function() {
                execicesService.post($scope.vm.currentTraining.id).success(function(res) {
                    _init();
                }).error(function(err) {

                });
            }

            var _getCurrentTraining = function() {
                trainingService.getCurrent().success(function(res) {
                    $scope.vm.currentTraining = res;
                    _init();
                }).error(function(err) {
                    $scope.vm.message = err;
                });
            }();

            var _init = function() {
                execicesService.getAll($scope.vm.currentTraining.id).success(function(res) {

                }).error(function(err) {

                });
            };
        }
    ]);
//.controller('ExecicesController', [
//    '$scope',
//    "$location",
//    'ExecicesService',
//    function ($scope, $location, execicesService) {





//        $scope.$watch('$scope.vm.currentTraining', function (o, n) {
//            debugger;
//            if (!!n) {
//                _init();
//            }
//        });
//    }
//])