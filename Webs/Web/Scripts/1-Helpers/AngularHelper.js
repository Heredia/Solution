var AngularHelper = new function () {
    this.$rootScope = function () {
        return angular.element(document.body).scope().$root;
    };
}