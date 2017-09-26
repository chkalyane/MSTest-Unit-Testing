angular.module('YesMed').controller('userCtrl', ['$scope', '$rootScope', '$http', function ($scope, $rootScope, $http) {
    //$scope.message = 'venkatesh';
    //var users = [{ UserId: 1, UserName: "Venkatesh", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'SuperAdmin', Status: 'Active', LastLogin: 'Nov 23, 2016 22:17 PM' },
    //               { UserId: 2, UserName: "kalyani", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 15, 2016 22:17 PM' },
    //               { UserId: 3, UserName: "chitti", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 4, UserName: "ravi", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 5, UserName: "epam", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2017Oct 22:17 PM' },
    //               { UserId: 6, UserName: "TechM", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 7, UserName: "vijji", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 8, UserName: "ramesh", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 9, UserName: "krish", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 10, UserName: "babu", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 11, UserName: "anthoney", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 12, UserName: "Venkatesh1", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 13, UserName: "jaggu", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 14, UserName: "sri", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 15, UserName: "test", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 16, UserName: "pavan", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 17, UserName: "james", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 18, UserName: "cheff", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 19, UserName: "jeffmories", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'User', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 20, UserName: "peter", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //               { UserId: 21, UserName: "DTV", Name: "Venkatesh Pydi", Email: 'venkatesh_pydi@epam.com', UserRole: 'Admin', Status: 'Active', LastLogin: 'Nov 13, 2016 22:17 PM' },
    //];

    $http.get($rootScope.apiURL + 'AdminUser/GetAll')
        .then(function (response) {
            debugger
            $scope.gridOptions.data = response.data;
        }, function (errorMessage) {
            console.log(errorMessage);
        });

    $scope.gridOptions = {
        paginationPageSizes: [25, 50, 75, 100],
        paginationPageSize: 5,
        enableFiltering: true,
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        },
        //data: users,
        columnDefs: [{ field: 'id', displayName: 'User Id', enableFiltering: false, visible: true, enableFiltering: false, enableSorting: false, sort: { direction: 'desc' } },
                    { field: 'fName', displayName: 'User Name' },
                     { field: 'lName', displayName: 'Name' },
                     { field: 'email', displayName: 'Email ID' },
                     { field: 'userTypeId', displayName: 'Role', enableFiltering: false, enableSorting: false },
                     { field: 'password', displayName: 'password', enableFiltering: false, enableSorting: false },
                     //{ field: 'Status', displayName: 'Stauts'  },
                     //{ field: 'LastLogin', displayName: 'Last LoggedIn', enableFiltering: false },
                     { field: 'Edit', displayName: 'Edit', enableFiltering: false, enableSorting: false, cellTemplate: '<a href="#/addUser/{{row.entity.id}}">Edit</a>' },
                     { field: 'Edit', displayName: 'Edit', enableFiltering: false, enableSorting: false, cellTemplate: '<a ng-click=deleteUser(row.entity.id)>Delete</a>' }]
    };

    $scope.deleteUser = function (userId) {
        debugger
        $http.post($rootScope.apiURL + 'AdminUser/DeleteUser/', userId)
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

