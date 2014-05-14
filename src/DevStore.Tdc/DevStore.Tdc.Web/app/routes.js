(function () {
    'use strict';
    var id = 'app';

    var app = angular.module('app', [
        'ngRoute'
    ]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController as vm',
                templateUrl: 'app/views/home/index.html'
               
            })
            .when('/produtos', {
                controller: 'ProductController as vm',
                templateUrl: 'app/views/product/index.html'
            });
    });
})();