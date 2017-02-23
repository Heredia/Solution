(function () {
    "use strict";

    angular.module("Services").service("UserService", UserService);

    UserService.$inject = ["$http", "$q", "SessionService"];

    function UserService($http, $q, SessionService) {
        this.Login = function (login) {
            return $http.post("UserService/Login", { login: login }).then(function (response) {
                SessionService.SetAuthentication(response.headers().authentication);
                return response;
            });
        };

        this.Logout = function () {
            return $http.post("UserService/Logout").then(function (response) {
                SessionService.Reset();
                return response;
            });
        };

        this.SelectUserById = function (userId) {
            return $http.post("UserService/SelectUserById", { userId: userId });
        };
    }
}());