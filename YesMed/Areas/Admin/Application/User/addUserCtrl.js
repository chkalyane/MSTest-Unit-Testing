angular.module('YesMed').controller('addUserCtrl', ['$scope', '$rootScope', '$routeParams', '$http', '$log', '$location', function ($scope, $rootScope, $routeParams, $http, $log, $location) {
    var UserId = $routeParams.Id;

    if ($routeParams.Id == undefined) {
        $scope.user = { id: 0, email: "", fName: "", lName: "", password: "", phone: "", userTypeId: "1" };
    }
    else {
        $http.get($rootScope.apiURL + 'AdminUser/GetUser/' + UserId)
        .then(function (response) {
            debugger
            //$scope.user = { UserId: 1, FirstName: "Venkatesh", LastName: "Pydi", UserName: "VenkateshPydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'SuperAdmin', Status: 'Active', Password: '123456', ConfPassword: '' };
            $scope.user = response.data;
            if ($rootScope.isLogging) {
                $log.log(response.data);
            }
        }, function (errorMessage) {
            console.log(errorMessage);
        });
    }

    $scope.UpdateUser = function (user) {
        debugger
        $http.post($rootScope.apiURL + 'AdminUser/UpdateUser/', $scope.user)
       .then(function (response) {
           if ($rootScope.isLogging) {
               $log.log(response.data);
           }
           $location.path('/user');
       }, function (errorMessage) {
           console.log(errorMessage);
       });
    }
}]);

