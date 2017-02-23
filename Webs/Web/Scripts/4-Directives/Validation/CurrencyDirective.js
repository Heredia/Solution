(function () {
    "use strict";

    angular.module("Directives").directive("valCurrency", CurrencyDirective);

    CurrencyDirective.$inject = ["$filter", "$locale"];

    function CurrencyDirective($filter, $locale) {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {
                element.bind("keypress", function (event) {
                    if (event.keyCode === 32) { event.preventDefault(); }
                });

                var decimalSeparator = $locale.NUMBER_FORMATS.DECIMAL_SEP;
                var groupSeparator = $locale.NUMBER_FORMATS.GROUP_SEP;
                var currencySymbol = $locale.NUMBER_FORMATS.CURRENCY_SYM + " ";

                function format(value) {
                    if (angular.isUndefined(value)) { return undefined; }

                    var isPositive = value.indexOf("+") > -1;
                    var isNegative = value.indexOf("-") > -1 && !isPositive;

                    if (attrs.valSignal) {
                        switch (attrs.valSignal) {
                            case "+": { isNegative = false; break; }
                            case "-": { isNegative = true; break; }
                        }
                    }

                    value = value.replace(/ /g, "").replace(/[^\d]/g, "");

                    var regexDecimalSeparator = new RegExp("\\" + decimalSeparator, "g");

                    var i = value.indexOf(decimalSeparator);
                    if (i === 0) {
                        value = value.replace(regexDecimalSeparator, "");
                    }

                    value = value.substr(0, i + 1) + value.substr(i + 1).replace(regexDecimalSeparator, "");

                    value = value.replace(/^0+(?!\.|$)/, "");

                    if (isNaN(value)) { value = "0"; }

                    value = value.toString().replace(/(\d\d?)$/, decimalSeparator + "$1");

                    if (value.length === 2) {
                        value = "0" + decimalSeparator + "0" + value.split(decimalSeparator)[1];
                    }
                    else if (value.length === 3) {
                        value = "0" + decimalSeparator + value.split(decimalSeparator)[1];
                    }
                    else if (!value) {
                        value = "0" + decimalSeparator + "00";
                    }

                    if (isNegative) { value = "-" + value; }

                    var decimalValue = value.replace(/\,/g, ".");

                    return decimalValue;
                }

                function parseCurrency(value) {
                    value = format(value);

                    if (attrs.valMax && !isNaN(attrs.valMax)) {
                        if (parseFloat(value) > parseFloat(attrs.valMax)) {
                            value = value.slice(0, -1);
                            value = format(value);
                        }
                    }

                    var viewValue = undefined;

                    var values = value.split(".");
                    if (values.length === 2) {
                        viewValue = values[0].replace(/\B(?=(\d{3})+(?!\d))/g, groupSeparator) + decimalSeparator + values[1];
                    }
                    else {
                        viewValue = value.replace(/\B(?=(\d{3})+(?!\d))/g, groupSeparator);
                    }

                    viewValue = currencySymbol + viewValue;

                    if (!value || parseFloat(value) === 0) { value = "0"; }

                    ctrl.$setViewValue(viewValue);
                    ctrl.$render();

                    return value;
                };

                ctrl.$parsers.push(function (data) { return parseCurrency(data); });
            }
        };
    };
}());