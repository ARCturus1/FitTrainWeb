angular.module('fitTraining.athorization.services', ['ngCookies'])
    .factory('authService', [
        '$http',
        '$q',
        '$cookies',
        function ($http, $q, $cookies) {
            console.log('in authService');
            var serviceBase = '';
            var authServiceFactory = {};

            var authentication = {
                isAuth: false,
                userName: ""
            };

            var logOut = function () {
                $cookies.remove('authorizationData');
                authentication.isAuth = false;
                authentication.userName = "";
            };

            var fillAuthData = function () {
                var authData = $cookies.getObject('authorizationData');
                if (authData) {
                    authentication.isAuth = true;
                    authentication.userName = authData.userName;
                }
            }

            var saveRegistration = function (registration) {
                logOut();
                return $http.post(serviceBase + 'api/account/register', registration).then(function (response) {
                    return response;
                });
            };

            var login = function (loginData) {
                var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;
                var deferred = $q.defer();

                $http.post(serviceBase + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (response) {
                    $cookies.putObject('authorizationData', { token: response.access_token, userName: loginData.userName });
                    authentication.isAuth = true;
                    authentication.userName = loginData.userName;
                    deferred.resolve(response);
                }).error(function (err, status) {
                    logOut();
                    deferred.reject(err);
                });
                return deferred.promise;
            };

            authServiceFactory.saveRegistration = saveRegistration;
            authServiceFactory.login = login;
            authServiceFactory.logOut = logOut;
            authServiceFactory.fillAuthData = fillAuthData;
            authServiceFactory.authentication = authentication;

            return authServiceFactory;
        }
    ])
    .factory('authInterceptorService', [
        '$q',
        '$location',
        '$cookies',
        function ($q, $location, $cookies) {
            debugger;
            var authInterceptorServiceFactory = {};

            var request = function (config) {
                config.headers = config.headers || {};
                var authData = $cookies.getObject('authorizationData');
                if (authData) {
                    config.headers.Authorization = 'Bearer ' + authData.token;
                }

                return config;
            }
            var responseError = function (rejection) {
                if (rejection.status === 401) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }

            authInterceptorServiceFactory.request = request;
            authInterceptorServiceFactory.responseError = responseError;

            return authInterceptorServiceFactory;
        }
    ]);