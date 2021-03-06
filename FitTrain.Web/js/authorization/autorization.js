﻿angular.module('fitTraining.athorization', ['ngRoute', 'fitTraining.athorization.controller', 'fitTraining.athorization.services'])
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when("/login", {
        templateUrl: "js/authorization/views/login.html"
    })
    .when("/register", {
        templateUrl: "js/authorization/views/register.html",
        controller: 'register'
    });
}]);