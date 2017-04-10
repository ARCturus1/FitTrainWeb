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
                    return $http.get('api/Trainings');
                },
                getCurrent: function() {
                    return $http.get('api/Trainings/GetCurrentTraining');
                },
                post: function() {
                    return $http.post('api/Trainings');
                }
            }
        }
    ]);