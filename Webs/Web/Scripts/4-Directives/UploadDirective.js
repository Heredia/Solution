(function () {
    "use strict";

    angular.module("Directives").directive("upload", UploadDirective);

    UploadDirective.$inject = ["$rootScope"];

    function UploadDirective($rootScope) {
        function link($scope, element) {
            $scope.inputChange = function (input) {
                if (!input || !input.files || input.files.length <= 0) return;
                var file = input.files[0];

                if (!$scope.isValidExtension(file)) {
                    $scope.resetInput(input);

                    if ($scope.onFileSelected()) { $scope.onFileSelected()(); }

                    if ($scope.onExtensionInvalid()) { $scope.onExtensionInvalid()(); }

                    alert($rootScope.Application.Resources.Texts.FileInvalidExtension);

                    return;
                }

                if (!$scope.isValidSize(file)) {
                    $scope.resetInput(input);

                    if ($scope.onFileSelected()) { $scope.onFileSelected()(); }

                    if ($scope.onSizeInvalid()) { $scope.onSizeInvalid()(); }

                    alert($rootScope.Application.Resources.Texts.FileInvalidSize);

                    return;
                }

                $scope.file = file;

                if ($scope.onFileSelected()) { $scope.onFileSelected()(file); }
            };

            $scope.$watch("file", function () {
                if (!$scope.file) { $scope.resetInput($(element[0])); }
            });

            $scope.resetInput = function (input) {
                $scope.file = undefined;
                var $input = $(input);
                $input.wrap("<form>").closest("form").get(0).reset();
                $input.unwrap();
            };

            $scope.isValidExtension = function (file) {
                if (!$scope.extensions || !file) return true;

                var regex = new RegExp("(.*?)\.(" + $scope.extensions + ")$");
                if (!(regex.test(file.name))) return false;

                return true;
            };

            $scope.isValidSize = function (file) {
                if (!$scope.size || !file || !file.size) return true;

                var fileSize = file.size / 1024 / 1024;
                if (fileSize > parseFloat($scope.size)) return false;

                return true;
            };
        }

        return {
            link: link,
            restrict: "E",
            template:
                "<input type='file' id='{{name}}' file='{{file}}' onchange='angular.element(this).scope().inputChange(this);' />" +
                "<label for='{{name}}'>{{text}}</label>",
            scope: {
                name: "@",
                text: "@",
                extensions: "@",
                size: "@",
                file: "=",
                onFileSelected: "&",
                onExtensionInvalid: "&",
                onSizeInvalid: "&"
            }
        };
    }
}());