angular.module('app', ['ngRoute', 'angular-loading-bar', 'ui.bootstrap', 'fitTraining.athorization',
    'fitTraining.userspace', 'fitTraining.training'])
    .config([
        '$routeProvider', '$httpProvider', function($routeProvider, $httpProvider) {
            //$routeProvider
            //    //.when('/home', {
            //    //    templateUrl: 'Views/home.html',
            //    //    controller: 'CatalogController'
            //    //})
            //    //.when('/home/:id', {
            //    //    templateUrl: 'Views/productDetails.html',
            //    //    controller: 'ProductController'
            //    //})
            //    //.when('/news', {
            //    //    templateUrl: 'Views/news.html',
            //    //    controller: 'NewsController'
            //    //})
            //    //.when('/news/:id', {
            //    //    templateUrl: 'Views/newEdit.html',
            //    //    controller: 'NewEditController'
            //    //})
            //    //.when('/login', {
            //    //    templateUrl: 'Views/login.html',
            //    //    controller: 'LoginController'
            //    //})
            //    //.when('/signup', {
            //    //    templateUrl: 'Views/signup.html',
            //    //    controller: 'SignupController'
            //    //})
            //    .otherwise({
            //        redirectTo: '/home'
            //    });
            $httpProvider.interceptors.push('authInterceptorService');
        }
    ])
    .run([
        'authService', function(authService) {
            authService.fillAuthData();
        }
    ])
    .controller('IndexController', [
        '$scope', '$location', 'authService', function($scope, $location, authService) {
            $scope.logOut = function() {
                authService.logOut();
                //$location.path('/home');
                window.history.back();
            }
            $scope.authentication = authService.authentication;

            //$scope.links = [{ name: 'Home', url: '#/home'}, { name: 'News', url: '#/news'}];
        }
    ]);