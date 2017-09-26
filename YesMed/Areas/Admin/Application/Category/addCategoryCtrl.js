angular.module('YesMed').controller('addCategoryCtrl', ['$scope', '$rootScope', '$routeParams','$http','$log', function ($scope, $rootScope, $routeParams,$http,$log) {
    
    var id = $routeParams.Id;
debugger    
    if (id == undefined) {
        $scope.category = { id: 0, name: "", image: "" };
    }
    else
    {
        $http.get($rootScope.apiURL + 'Category/'+id)
        .then(function (response) {
            debugger
            //$scope.category = { id: 0, name: "test", image: "test" };
            $scope.category = response.data[0];
            if ($rootScope.isLogging) {
                $log.log(response.data);
                    }
        }, function (errorMessage) {
            console.log(errorMessage);
        });
    }

    $scope.getImage = function (image) {
        debugger
        return image.replace(/\\/g, '/');
    };

    $scope.UpdateCategory = function (category)
    {
        debugger
        $http.post($rootScope.apiURL + 'category/Add/', $scope.category)
       .then(function (response) {
           if ($rootScope.isLogging) {
               $log.log(response.data);
           }
       }, function (errorMessage) {
           console.log(errorMessage);
       });
    }
}]);

