(function () {
    "use strict";

    angular.module("Controllers").controller("UserListController", UserListController);

    UserListController.$inject = ["$scope", "UserService"];

    function UserListController($scope, UserService) {
        $scope.SelectUser = function (userId) {
            UserService.SelectUserById(userId).then(function (response) {
                alert("[SELECT] UserId: " + response.data.UserId);
            });
        };

        $scope.EditUser = function (userId) {
            alert("[EDIT] UserId: " + userId);
        };

        $scope.DeleteUser = function (userId) {
            alert("[DELETE] UserId: " + userId);
        };
    }
}());