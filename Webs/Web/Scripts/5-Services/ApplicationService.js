(function () {
    "use strict";

    angular.module("Services").service("ApplicationService", ApplicationService);

    ApplicationService.$inject = ["$http"];

    function ApplicationService($http) {
        this.LoadApplication = function () {
            return $http.post("ApplicationService/LoadApplication");
        };
    }
}());