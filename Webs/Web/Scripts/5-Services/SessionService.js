(function () {
    "use strict";

    angular.module("Services").service("SessionService", SessionService);

    SessionService.$inject = ["$localStorage"];

    function SessionService($localStorage) {
        this.GetAuthentication = function () {
            return $localStorage.Authentication;
        };

        this.SetAuthentication = function (authentication) {
            $localStorage.Authentication = authentication;
        };

        this.Reset = function () {
            $localStorage.$reset();
        };
    }
}());