'use strict';
angular.module('fitTraining.athorization.controller', [])
    .controller('RegisterController', [
        'authService', function (authService) {
            var self = this;
            var _init = function () {
                self.authorization = {
                    userName: "",
                    email: "",
                    password: "",
                    confirmPassword: ""
                };
                self.message = '';
            }();
            var startTimer = function () {
                var timer = $timeout(function () {
                    $timeout.cancel(timer);
                    $location.path('/login');
                }, 2000);
            }

            this.authorization.register = function () {
                authService.saveRegistration(self.authorization).then(function (response) {

                    self.authorization.savedSuccessfully = true;
                    self.authorization.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                    startTimer();

                },
                    function (response) {
                        var errors = [];
                        for (var key in response.data.modelState) {
                            if (response.data.modelState.hasOwnProperty(key)) {
                                for (var i = 0; i < response.data.modelState[key].length; i++) {
                                    errors.push(response.data.modelState[key][i]);
                                }
                            }
                        }
                        self.authorization.message = "Failed to register user due to:" + errors.join(' ');
                    });
            }
        }
    ])
    .controller('IndexController', [
        '$scope', '$location', 'authService', function ($scope, $location, authService) {
            $scope.logOut = function () {
                authService.logOut();
                //$location.path('/home');
                window.history.back();
            }
            $scope.authentication = authService.authentication;

            //$scope.links = [{ name: 'Home', url: '#/home'}, { name: 'News', url: '#/news'}];
        }
    ])
    .controller('SignupController', [
        '$scope', '$location', '$timeout', 'authService', function ($scope, $location, $timeout, authService) {

            $scope.savedSuccessfully = false;
            $scope.message = "";

            $scope.registration = {
                userName: "",
                password: "",
                confirmPassword: ""
            };

            var startTimer = function () {
                var timer = $timeout(function () {
                    $timeout.cancel(timer);
                    $location.path('/login');
                }, 2000);
            }

            $scope.signUp = function () {

                authService.saveRegistration($scope.registration).then(function (response) {

                    $scope.savedSuccessfully = true;
                    $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                    startTimer();

                },
                    function (response) {
                        var errors = [];
                        for (var key in response.data.modelState) {
                            if (response.data.modelState.hasOwnProperty(key)) {
                                for (var i = 0; i < response.data.modelState[key].length; i++) {
                                    errors.push(response.data.modelState[key][i]);
                                }
                            }
                        }
                        $scope.message = "Failed to register user due to:" + errors.join(' ');
                    });
            };
        }
    ])
    .controller('LoginController', [
        '$scope', '$location', 'authService', function ($scope, $location, authService) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.message = "";

            $scope.login = function () {

                authService.login($scope.loginData).then(function (response) {
                    $location.path('/home');
                },
                    function (err) {
                        $scope.message = err.error_description;
                    });
            };

        }
    ]);