(function () {
    "use strict";

    angular.module("Directives").directive("file", FileDirective);

    FileDirective.$inject = ["$parse"];

    function FileDirective($parse) {
        function link(scope, element, attrs) {
            var model = $parse(attrs.file);
            var modelSetter = model.assign;

            element.bind("change", function () {
                scope.$apply(function () {
                    try {
                        modelSetter(scope, element[0].files[0]);
                    } catch (e) { }
                });
            });
        }

        return { link: link, restrict: "A" };
    };
}());