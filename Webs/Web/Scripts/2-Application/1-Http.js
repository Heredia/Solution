(function () {
    "use strict";

    angular.module("Configs").config(ConfigHttpProvider);

    ConfigHttpProvider.$inject = ["$httpProvider"];

    function ConfigHttpProvider($httpProvider) {
        $httpProvider.defaults.timeout = 5000;

        $httpProvider.interceptors.push(["$q", "$location", "SessionService", HttpInterceptor]);

        function HttpInterceptor($q, $location, SessionService) {
            return {
                request: function (request) {
                    request.headers = request.headers || {};
                    request.headers.Authentication = SessionService.GetAuthentication();

                    LogRequest(request);
                    return $q.resolve(request);
                },
                response: function (response) {
                    LogResponse(response);
                    return $q.resolve(response);
                },
                responseError: function (response) {
                    if (response.status === 401 || response.status === 403) {
                        $location.path("/$/Login");
                    }

                    console.log("[ERROR]: " + response.data);
                    return $q.reject(response);
                }
            };
        };
    }

    function LogRequest(request) {
        if (!request || request.method !== "POST") { return; }
        console.log("[REQUEST]: " + request.url, request.data);
    }

    function LogResponse(response) {
        if (!response || response.config.method !== "POST") { return; }
        console.log("[RESPONSE]: " + response.config.url, response.data);
        console.log("\n");
    }
}());