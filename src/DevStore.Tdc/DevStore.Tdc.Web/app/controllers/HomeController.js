(function () {
    'use strict';

    var controllerId = 'HomeController';

    // TODO: replace app with your module name
    angular.module('app').controller(controllerId,
        ['$scope', HomeController]);

    function HomeController($scope) {
        var vm = this;

        vm.activate = activate;
        vm.title = 'HomeController';

        function activate() { }
    }
})();
