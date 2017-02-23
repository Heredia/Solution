(function () {
    "use strict";

    angular.module("Controllers").controller("MenuController", MenuController);

    MenuController.$inject = ["$scope", "$location", "UserService"];

    function MenuController($scope, $location, UserService) {
        var pathsMenuInvisible = ["/$/Login"];

        $scope.$on("$locationChangeSuccess", function () {
            $scope.IsMenuVisible = pathsMenuInvisible.indexOf($location.path()) === -1;
        });

        $scope.IsMenuItemActive = function (route) {
            return route === $location.path();
        };

        $scope.Logout = function () {
            UserService.Logout().then(function () {
                $location.path("/$/Login");
            });
        };
    }
}());