(function () {
    "use strict";

    angular.module("Configs").config(ConfigRouteProvider);

    ConfigRouteProvider.$inject = ["$routeProvider"];

    function ConfigRouteProvider($routeProvider) {
        $routeProvider
            .when("/$/Home", GetRoute("Home"))
            .when("/$/Login", GetRoute("Login"))
            .when("/$/Template", GetRoute("Template"))
            .when("/$/Upload", GetRoute("Upload"))
            .when("/$/UserList", GetRoute("UserList"))
            .when("/$/Validation", GetRoute("Validation"))
            .when("/", { redirectTo: "/$/Login" })
            .otherwise({ redirectTo: "/" });
    }

    function GetRoute(route) {
        return {
            controller: route + "Controller",
            templateUrl: "Views/" + route + "/" + route
        };
    }
}());