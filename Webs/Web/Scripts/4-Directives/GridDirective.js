(function () {
    "use strict";

    angular.module("Directives").directive("grid", GridDirective);

    GridDirective.$inject = ["$http", "$timeout"];

    function GridDirective($http, $timeout) {
        function link($scope, element, attrs, ctrl, transclude) {
            $scope.Filters = [];
            $scope.Columns = [];
            $scope.PageSize = 5;
            $scope.PagesRange = 3;

            transclude(function (childs) {
                for (var i = 0; i < childs.length; i++) {
                    if (childs[i] instanceof Text) continue;

                    var child = angular.element(childs[i]);
                    var tag = childs[i].tagName;

                    if (tag === "CONFIGURATION") {
                        $scope.Url = child.attr("url");
                    }

                    if (tag === "FILTER") {
                        $scope.Filters.push({
                            Property: child.attr("property"),
                            Label: child.attr("label"),
                            Type: child.attr("type"),
                            MaxLength: child.attr("maxlength"),
                            Condition: child.attr("condition")
                        });
                    }

                    if (tag === "COLUMN") {
                        $scope.Columns.push({
                            Property: child.attr("property"),
                            Label: child.attr("label"),
                            Css: child.attr("class"),
                            Width: child.attr("width"),
                            Orderable: child.attr("orderable"),
                            Content: child.html()
                        });
                    }
                }
            });

            $scope.Init = function () {
                $scope.Reset();
                $scope.Load();
            };

            $scope.Empty = {
                List: [],
                Count: 0,
                Parameters: {
                    Order: {
                        Property: $scope.Columns[0].Property,
                        IsAscending: true
                    },
                    Page: {
                        Index: 1,
                        Size: $scope.PageSize
                    }
                }
            };

            $scope.Reset = function () {
                $scope.PagedList = $scope.Empty;
                $scope.IsEmpty = true;
                $scope.IsError = false;
                $scope.IsLoading = false;
            };

            $scope.PagesTotal = function () {
                return Math.ceil($scope.PagedList.Count / $scope.PagedList.Parameters.Page.Size);
            };

            $scope.HasPagination = function () {
                return !$scope.IsLoading && $scope.PagesTotal() > 1;
            };

            $scope.HasNavigationPages = function () {
                return $scope.PagesTotal() > $scope.PagesRange;
            };

            $scope.HasPreviousPage = function () {
                return $scope.PagedList.Parameters.Page.Index > 1 && $scope.HasNavigationPages();
            };

            $scope.PreviousPage = function () {
                return $scope.HasPreviousPage() ? $scope.PagedList.Parameters.Page.Index - 1 : 1;
            };

            $scope.HasNextPage = function () {
                return $scope.PagedList.Parameters.Page.Index < $scope.PagesTotal() && $scope.HasNavigationPages();
            };

            $scope.NextPage = function () {
                return $scope.HasNextPage() ? $scope.PagedList.Parameters.Page.Index + 1 : $scope.PagesTotal();
            };

            $scope.Pages = function () {
                var pageIndex = $scope.PagedList.Parameters.Page.Index;
                var pagesRange = $scope.PagesRange;
                pagesRange = pagesRange % 2 === 0 ? pagesRange + 1 : pagesRange;
                var limit = Math.ceil((pagesRange - 1) / 2);
                var pages = [];

                var firstPage = pageIndex - limit;
                if (firstPage < 1) { firstPage = 1; }
                if (firstPage > $scope.PagesTotal() - pagesRange) { firstPage = $scope.PagesTotal() - pagesRange + 1; }

                for (var i = firstPage; i < firstPage + pagesRange; i++) { pages.push(i); }
                return pages;
            };

            $scope.IsCurrentPage = function (page) {
                return page === $scope.PagedList.Parameters.Page.Index;
            };

            $scope.SelectPage = function (index) {
                if ($scope.IsCurrentPage(index)) return;
                $scope.PagedList.Parameters.Page.Index = index;
                $scope.Load();
            };

            $scope.SortBy = function (property) {
                var order = $scope.PagedList.Parameters.Order;
                order.Property = property;
                order.IsAscending = !order.IsAscending;
                $scope.Load();
            };

            $scope.SelectFilter = function () {
                $scope.FilterValue = null;

                angular.forEach($scope.Filters, function (item) {
                    item.IsVisible = false;
                    item.Value = null;

                    if (item.Property === $scope.FilterProperty) {
                        item.IsVisible = true;
                    }
                });
            };

            $scope.GetFilter = function () {
                var filter = {
                    Property: $scope.FilterProperty,
                    Condition: "Default",
                    Value: $scope.FilterValue
                };

                if ($scope.FilterProperty) {
                    angular.forEach($scope.Filters, function (item) {
                        if (item.Property === $scope.FilterProperty) {
                            if (item.Condition) { filter.Condition = item.Condition; }
                            if (item.Value) { filter.Value = item.Value; }
                        }
                    });
                }

                return filter;
            };

            $scope.Search = function () {
                $scope.Reset();
                $scope.PagedList.Parameters.Filter = $scope.GetFilter();
                $scope.Load();
            };

            $scope.Load = function () {
                $scope.IsEmpty = false;
                $scope.IsError = false;

                var timeout = $timeout(function () {
                    $scope.IsLoading = true;
                }, 750);

                $http.post($scope.Url, { parameters: $scope.PagedList.Parameters })
                    .then(function success(response) {
                        $timeout.cancel(timeout);

                        if (!response.data || !response.data.Parameters || !response.data.Count || !response.data.List) {
                            $scope.Reset();
                        }
                        else {
                            $scope.PagedList = response.data;
                            $scope.IsLoading = false;
                        }
                    }, function error() {
                        $timeout.cancel(timeout);

                        $scope.Reset();
                        $scope.IsError = true;
                    });
            };

            $scope.Init();
        }

        return {
            link: link,
            restrict: "E",
            transclude: true,
            templateUrl: "/Scripts/4-Directives/GridDirective.html",
            scope: true
        };
    }
}());