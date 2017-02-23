(function () {
    "use strict";

    angular.module("Directives").directive("ngEnter", EnterKeyDirective);

    function EnterKeyDirective() {
        return function (scope, element, attrs) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 13) {
                    scope.$apply(function () {
                        scope.$eval(attrs.ngEnter, { 'event': event });
                    });

                    event.preventDefault();
                }
            });
        };
    }
}());