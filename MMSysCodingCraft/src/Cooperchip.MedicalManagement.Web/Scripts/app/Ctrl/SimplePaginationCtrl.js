

(function () {
    'use strict';

    app.controller('SimplePaginationCtrl', ['$scope', '$http', 'SimplePaginate', function ($scope, $http, SimplePaginate) {
        var success = function (response) {
            SimplePaginate.configure(
                {
                    data: response.data.data,
                    perPage: 10
                });
            $scope.paginate = {
                result: SimplePaginate.goToPage(0),
                total: SimplePaginate.itemsTotal(),
                next: function () {
                    $scope.paginate.result = SimplePaginate.next();
                },
                prev: function () {
                    $scope.paginate.result = SimplePaginate.prev();
                }
            };
        }
        
        $http.get("/resources/data.json").then(success);
        
    }]);
})()