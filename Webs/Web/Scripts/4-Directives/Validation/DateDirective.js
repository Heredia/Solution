(function () {
    "use strict";

    angular.module("Directives").directive("valDate", DateDirective);

    function DateDirective() {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {
                var regexDateDDMMYYYY = /^((((0?[1-9]|[12]\d|3[01])[\.\-\/](0?[13578]|1[02])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\.\-\/](0?[13456789]|1[012])[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?\d{2}))|(29[\.\-\/]0?2[\.\-\/]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))) ?((20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2}))?$/;
                var months31 = [1, 3, 5, 7, 8, 10, 12];

                element.bind("keypress", function (event) {
                    if (event.keyCode === 32) { event.preventDefault(); }
                });

                element.bind("keydown", function (event) {
                    if (event.keyCode === 8) {
                        scope.$apply(function () {
                            if (element.val()[element.val().length - 1] === "/") {
                                element.val(element.val().slice(0, -1));
                                scope.ngModel = element.val();
                            }
                        });
                    }
                });

                element.bind("blur", function () {
                    if (!regexDateDDMMYYYY.test(element.val())) {
                        scope.$apply(function () {
                            ctrl.$setViewValue(undefined);
                            ctrl.$render();
                        });
                    }
                });

                function isLeapYear(year) {
                    return ((year % 4 === 0) && (year % 100 !== 0)) || (year % 400 === 0);
                }

                function formatDDMMYYYY(value) {
                    value = value.replace(/[^0-9]/g, "");

                    if (value.length > 8) {
                        value = value.substr(0, 8);
                    }

                    switch (value.length) {
                        case 1: {
                            if (parseInt(value[0]) > 3) {
                                value = "0" + value[0];
                            }

                            break;
                        }
                        case 2: {
                            if ((parseInt(value[0]) === 0 && parseInt(value[1]) === 0) ||
                                (parseInt(value[0]) === 3 && parseInt(value[1]) > 1)) {
                                value = value.slice(0, -1);
                            }

                            break;
                        }
                        case 3: {
                            if ((parseInt(value[0] + value[1]) === 31 && value[2] !== "0" && months31.indexOf(parseInt(value[2])) === -1) ||
                                (parseInt(value[0] + value[1]) === 30 && value[2] === "2")) {
                                value = value.slice(0, -1);
                            } else if (parseInt(value[2]) > 1) {
                                value = value.substr(0, 2) + "0" + value[2];
                            }

                            break;
                        }
                        case 4: {
                            if ((parseInt(value[2]) === 0 && parseInt(value[3]) === 0) ||
                                (parseInt(value[2]) === 1 && parseInt(value[3]) > 2)) {
                                value = value.slice(0, -1);
                            }

                            if ((parseInt(value[0] + value[1]) === 31 && months31.indexOf(parseInt(value[2] + value[3])) === -1) ||
                                (parseInt(value[0] + value[1]) === 30 && value[2] + value[3] === "02")) {
                                value = value.slice(0, -1);
                            }

                            break;
                        }
                        case 8: {
                            var day = parseInt(value[0] + value[1]);
                            var month = parseInt(value[2] + value[3]);
                            var year = parseInt(value[4] + value[5] + value[6] + value[7]);

                            if (day === 29 && month === 2 && !isLeapYear(year)) {
                                value = value.slice(0, -1);
                            }

                            break;
                        }
                    }

                    var val = "";

                    for (var i = 0; i < value.length; i++) {
                        val += value[i];
                        if (i === 1 || i === 3) { val += "/"; }
                    }

                    return val;
                }

                function parseDate(value) {
                    if (angular.isUndefined(value)) { return undefined; }

                    value = formatDDMMYYYY(value);

                    ctrl.$setViewValue(value);
                    ctrl.$render();

                    return value;
                };

                ctrl.$parsers.push(function (data) { return parseDate(data); });
            }
        };
    };
}());