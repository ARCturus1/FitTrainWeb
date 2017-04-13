'use strict';
angular.module('fitTraining.training.services', [])
    .factory('TrainingService',
    [
        '$http',
        function($http) {
            return {
                getAll: function() {
                    return $http.get('api/Trainings');
                },
                get: function(id) {
                    debugger;
                    return $http.get('api/Trainings/' + id);
                },
                getCurrent: function() {
                    return $http.get('api/Trainings/GetCurrentTraining');
                },
                post: function() {
                    return $http.post('api/Trainings');
                }
            }
        }
    ])
    .factory('ExecicesService',
    [
        '$http',
        function($http) {
            return {
                getAll: function(id) {
                    return $http.get('api/Exercises?trainingId=' + id);
                },
                get: function(id) {
                    return $http.get('api/Exercises');
                },
                getCurrent: function() {
                    return $http.get('api/Exercises/GetCurrentTraining');
                },
                post: function(exercise) {
                    return $http.post('api/Exercises', exercise);
                }
            }
        }
    ])
    .factory('ExerciseTypesService',
    [
        '$http',
        function($http) {
            return {
                getAll: function() {
                    return $http.get('api/ExerciseTypes');
                }
            }
        }
    ]);