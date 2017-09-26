angular.module('YesMed').controller('productsCtrl', ['$scope', '$rootScope', '$http', '$log', function ($scope, $rootScope, $http, $log) {

    $http.get($rootScope.apiURL + 'Products/GetAllProducts')
        .then(function (response) {
            debugger
            $scope.gridOptions.data = response.data;
            if ($rootScope.isLogging) {
                $log.log(response.data);
            }
        }, function (errorMessage) {
            if ($rootScope.isLogging) {
                $log.log(errorMessage);
            }
        });

    $scope.gridOptions = {
        paginationPageSizes: [25, 50, 75, 100],
        paginationPageSize: 5,
        enableFiltering: true,
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        },
        rowHeight: 80,
        columnDefs: [{ field: 'id', displayName: 'User Id', enableFiltering: false, visible: false, enableFiltering: false, enableSorting: false },
                    { field: 'name', displayName: 'Product Name' },
                    { field: 'image', displayName: 'Image', enableFiltering: false, enableSorting: false, cellTemplate: '<img   ng-src="../../Assets/img/products/{{grid.getCellValue(row, col)}}" lazy-src>"' },
                     { field: 'Edit', displayName: 'Edit', enableFiltering: false, enableSorting: false, cellTemplate: '<a href="#/addProducts/{{row.entity.id}}">Edit</a>' }]
    };

}]);

