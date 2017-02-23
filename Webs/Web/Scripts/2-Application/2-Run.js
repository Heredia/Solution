(function () {
    "use strict";

    angular.module("Application").run(ApplicationRun);

    ApplicationRun.$inject = ["$rootScope", "ApplicationService"];

    function ApplicationRun($rootScope, ApplicationService) {
        ApplicationService.LoadApplication().then(function (response) {
            $rootScope.Application = response.data;
        });
    }
}());