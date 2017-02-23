(function () {
    "use strict";

    angular.module("Directives").directive("valInteger", IntegerDirective);

    function IntegerDirective() {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {
                element.bind("keypress", function (event) {
                    if (event.keyCode === 32) { event.preventDefault(); }
                });

                element.bind("blur", function () {
                    if (isNaN(element.val())) {
                        scope.$apply(function () {
                            ctrl.$setViewValue(undefined);
                            ctrl.$render();
                        });
                    }
                });

                function parseInteger(value) {
                    if (angular.isUndefined(value)) { return undefined; }

                    var isPositive = value.indexOf("+") > -1;
                    var isNegative = value.indexOf("-") > -1 && !isPositive;

                    if (attrs.valSignal) {
                        switch (attrs.valSignal) {
                            case "+": { isNegative = false; break; }
                            case "-": { isNegative = true; break; }
                        }
                    }

                    value = value.replace(/[^0-9]/g, "").replace(/^0+(?!\.|$)/, "");

                    if (isNegative) { value = "-" + value; }

                    if (attrs.valMax && !isNaN(attrs.valMax)) {
                        if (parseInt(value) > parseInt(attrs.valMax)) {
                            value = value.slice(0, -1);
                        }
                    }

                    if (parseInt(value) === 0) { value = "0"; }

                    ctrl.$setViewValue(value);
                    ctrl.$render();

                    return value;
                };

                ctrl.$parsers.push(function (data) { return parseInteger(data); });
            }
        };
    };
}());