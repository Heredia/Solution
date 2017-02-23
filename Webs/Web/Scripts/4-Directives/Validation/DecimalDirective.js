(function () {
    "use strict";

    angular.module("Directives").directive("valDecimal", DecimalDirective);

    DecimalDirective.$inject = ["$filter", "$locale"];

    function DecimalDirective($filter, $locale) {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {
                var decimalSeparator = $locale.NUMBER_FORMATS.DECIMAL_SEP;
                var regex = new RegExp("[^0-9\\" + decimalSeparator + "]", "g");
                var regexLeadingZeros = new RegExp("^0+(?!\\" + decimalSeparator + "|$)");

                element.bind("keypress", function (event) {
                    if (event.keyCode === 32) { event.preventDefault(); }
                });

                element.bind("blur", function () {
                    var value = undefined;
                    var isInvalid = false;

                    if (parseInt(element.val().replace(/[^0-9]/g, "")) === 0) {
                        value = "0";
                        isInvalid = true;
                    } else if (element.val().indexOf(decimalSeparator) === element.val().length - 1) {
                        value = element.val().slice(0, -1);
                        isInvalid = true;
                    } else if (isNaN(element.val())) {
                        value = undefined;
                        isInvalid = true;
                    }

                    if (isInvalid) {
                        scope.$apply(function () {
                            ctrl.$setViewValue(value);
                            ctrl.$render();
                        });
                    }
                });

                function parseDecimal(value) {
                    if (angular.isUndefined(value)) { return undefined; }

                    var isPositive = value.indexOf("+") > -1;
                    var isNegative = value.indexOf("-") > -1 && !isPositive;

                    if (attrs.valSignal) {
                        switch (attrs.valSignal) {
                            case "+": { isNegative = false; break; }
                            case "-": { isNegative = true; break; }
                        }
                    }

                    value = value.replace(regex, "");

                    var i = value.indexOf(decimalSeparator);
                    if (i === 0) {
                        value = value.replace(decimalSeparator, "");
                    }

                    value = value.substr(0, i + 1) + value.substr(i + 1).replace(decimalSeparator, "");

                    value = value.replace(regexLeadingZeros, "");

                    if (isNegative) { value = "-" + value; }

                    if (attrs.valPlaces && !isNaN(attrs.valPlaces)) {
                        var values = value.split(decimalSeparator);

                        if (values.length === 2) {
                            value = values[0] + decimalSeparator + values[1].substr(0, parseInt(attrs.valPlaces));
                        }
                    }

                    var decimalValue = value.replace(/\,/g, ".");

                    if (attrs.valMax && !isNaN(attrs.valMax)) {
                        if (parseFloat(decimalValue) > parseFloat(attrs.valMax)) {
                            value = value.slice(0, -1);
                            decimalValue = value.replace(/\,/g, ".");
                        }
                    }

                    ctrl.$setViewValue(value);
                    ctrl.$render();

                    return decimalValue;
                };

                ctrl.$parsers.push(function (data) { return parseDecimal(data); });
            }
        };
    };
}());