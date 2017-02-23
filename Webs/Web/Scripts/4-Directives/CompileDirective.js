(function () {
    "use strict";

    angular.module("Directives").directive("compile", CompileDirective);

    CompileDirective.$inject = ["$compile"];

    function CompileDirective($compile) {
        return function (scope, element, attrs) {
            scope.$watch(
              function (childScope) {
                  return childScope.$eval(attrs.compile);
              },
              function (value) {
                  element.html(value);
                  $compile(element.contents())(scope);
              }
           );
        };
    };
}());