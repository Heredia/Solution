(function () {
    "use strict";

    angular.module("Configs").config(ConfigLocationProvider);

    ConfigLocationProvider.$inject = ["$locationProvider"];

    function ConfigLocationProvider($locationProvider) {
        $locationProvider.html5Mode(true);
    }
}());