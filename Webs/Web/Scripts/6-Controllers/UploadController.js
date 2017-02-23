(function () {
    "use strict";

    angular.module("Controllers").controller("UploadController", UploadController);

    UploadController.$inject = ["$scope", "UploadService"];

    function UploadController($scope, UploadService) {
        $scope.Uploads = [
            {
                Id: 1,
                Name: "Name 1",
                Description: "Description 1",
                File: null
            },
            {
                Id: 2,
                Name: "Name 2",
                Description: "Description 2",
                File: null
            }
        ];

        $scope.Upload = function () {
            if (!$scope.Uploads) return;

            angular.forEach($scope.Uploads, function (value) {
                UploadService.Upload(value).then(function (result) {
                    alert("Success!");
                });
            });
        }
    }
}());