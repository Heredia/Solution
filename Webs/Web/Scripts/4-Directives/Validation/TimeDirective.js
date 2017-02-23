(function () {
    "use strict";

    angular.module("Directives").directive("valTime", TimeDirective);

    function TimeDirective() {
        return {
            restrict: "A",
            require: "ngModel",
            link: function (scope, element, attrs, ctrl) {
                var regexTimeHHMM = /^(20|21|22|23|[01]\d|\d)(([:.][0-5]\d){1,2})$/;

                element.bind("keypress", function (event) {
                    if (event.keyCode === 32) { event.preventDefault(); }
                });

                element.bind("keydown", function (event) {
                    if (event.keyCode === 8) {
                        scope.$apply(function () {
                            if (element.val()[element.val().length - 1] === ":") {
                                element.val(element.val().slice(0, -1));
                                scope.ngModel = element.val();
                            }
                        });
                    }
                });

                element.bind("blur", function () {
                    if (!regexTimeHHMM.test(element.val())) {
                        scope.$apply(function () {
                            ctrl.$setViewValue(undefined);
                            ctrl.$render();
                        });
                    }
                });

                function parseTime(value) {
                    if (angular.isUndefined(value)) { return undefined; }

                    value = value.replace(/[^0-9]/g, "");

                    if (value.length > 4) { value = value.substr(0, 4); }

                    switch (value.length) {
                        case 1: {
                            if (parseInt(value[0]) > 2) { value = value.slice(0, -1); }
                            break;
                        }
                        case 2: {
                            if (value[0] === 2 && parseInt(value[1]) > 3) { value = value.slice(0, -1); }
                            break;
                        }
                        case 3: {
                            if (parseInt(value[2]) > 5) { value = value.slice(0, -1); }
                            break;
                        }
                    }

                    var val = "";

                    for (var i = 0; i < value.length; i++) {
                        val += value[i];
                        if (i === 1) { val += ":"; }
                    }

                    ctrl.$setViewValue(val);
                    ctrl.$render();

                    return val;
                };

                ctrl.$parsers.push(function (data) { return parseTime(data); });
            }
        };
    };
}());