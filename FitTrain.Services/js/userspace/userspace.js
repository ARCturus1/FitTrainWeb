angular.module('fitTraining.userspace', ['fitTraining.userspace.controller', 'fitTraining.userspace.services'])
    .config([
        '$routeProvider', function ($routeProvider) {
            $routeProvider
                .when("/",
                {
                    templateUrl: "js/userspace/views/userspace.html",
                    controller: "UserspaceController"
                })
                .when("/userspace",
                {
                    templateUrl: "js/userspace/views/userspace.html",
                    controller: "UserspaceController"
                })
                .when("/newUserSpace",
                {
                    templateUrl: "js/userspace/views/new.html",
                    controller: 'NewUserSpace'
                });
        }
    ]);