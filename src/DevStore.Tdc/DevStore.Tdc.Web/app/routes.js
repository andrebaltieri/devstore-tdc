(function () {
    'use strict';
    var id = 'app';

    var app = angular.module('app', [
        'ngAnimate',
        'ngRoute'
    ]);

    app.config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController as vm',
                templateUrl: 'app/views/home/index.html',
                resolve: {
                    action: function () { return 'list'; }
                }
            })
            .when('/produtos', {
                controller: 'ProductController as vm',
                templateUrl: 'app/views/product/index.html',
                resolve: {
                    action: function () { return 'list'; }
                }
            });
    });
})();