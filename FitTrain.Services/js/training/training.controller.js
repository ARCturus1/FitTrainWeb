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
                items: []
                //lastSetting: null,
                //mode: 2,
                //settings: null
            };

            trainingService.getAll().success(function (res) {
                debugger;
                if (res != null)
                    $scope.model.items = res;
            }).error(function (err) {
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
        '$routeParams',
        'TrainingService',
        'ExecicesService',
        'ExerciseTypesService',
        function ($scope, $location, $routeParams, trainingService, execicesService, exerciseTypesService) {
            $scope.vm = {
                message: '',
                currentTraining: null,
                excerciseTypesList: []
            };
            $scope.model = {
                execices: [],
                extype: null
            };

            var id = $routeParams.id;

            var _errorCalBack = function (err) {
                $scope.vm.message = err;
            };
            var _getTraining = !!id ? trainingService.get(id) : trainingService.getCurrent();

            var _getExercices = function () {
                execicesService.getAll($scope.vm.currentTraining.id).success(function (res) {
                    $scope.model.execices = res;
                }).error(_errorCalBack);
            };
            var _getCurrentTraining = function() {
                exerciseTypesService.getAll().success(function(res) {
                    $scope.vm.excerciseTypesList = !!res ? res : null;
                }).error(_errorCalBack);

                _getTraining.success(function(res) {
                    $scope.vm.currentTraining = res;
                    _getExercices();
                }).error(_errorCalBack);
            };

            $scope.vm.addExe = function () {
                var exercise = {
                    ExerciseTypeId: $scope.model.extype.id,
                    TrainingId: $scope.vm.currentTraining.id
                }
                execicesService.post(exercise).success(function (res) {
                    _getExercices();
                }).error(_errorCalBack);
            }
            $scope.vm.openExe = function(exeId) {
                //debugger;
            }

            _getCurrentTraining();
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