(function () {
    "use strict";

    angular.module("Services").service("UploadService", UploadService);

    UploadService.$inject = ["$http"];

    function UploadService($http) {
        this.Upload = function (upload) {
            var formData = new FormData();

            angular.forEach(upload, function (value, key) {
                formData.append(key, value);
            });

            return $http.post("/UploadService/Upload", formData, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
        };
    }
}());