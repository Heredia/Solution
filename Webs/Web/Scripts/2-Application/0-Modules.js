(function () {
    "use strict";

    angular.module("Services", ["ngStorage"]);

    angular.module("Configs", ["ngRoute", "Services"]);

    angular.module("Filters", []);

    angular.module("Directives", ["Services", "Filters"]);

    angular.module("Controllers", ["Directives", "Services"]);

    angular.module("Application", ["Configs", "Directives", "Services", "Controllers",
        "ngRoute", "ngSanitize", "ngStorage", "angular.filter"]);
}());