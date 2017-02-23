(function () {
    "use strict";

    angular.module("Controllers").controller("LoginController", LoginController);

    LoginController.$inject = ["$scope", "$location", "UserService"];

    function LoginController($scope, $location, UserService) {
        $scope.Login = function () {
            var login = { Login: "admin", Password: "admin" };

            UserService.Login(login).then(function (response) {
                $location.path("/$/Home");
            });
        };
    }
}());