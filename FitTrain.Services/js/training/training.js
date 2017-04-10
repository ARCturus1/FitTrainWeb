'use strict';
angular.module('fitTraining.training', ['fitTraining.training.controller', 'fitTraining.training.services'])
    .config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider
                .when("/training",
                {
                    templateUrl: "js/training/views/training.html",
                    controller: "TrainingController"
                })
                .when("/newtraining",
                {
                    templateUrl: "js/training/views/new.html",
                    controller: 'NewTraining'
                });
        }
    ]);