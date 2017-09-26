yesMedAdmin.controller('categoryCtrl', ['$scope', '$http', '$rootScope','categoryService', function ($scope, $http, $rootScope,categoryService) {
    //$scope.getImage = function (image) {
    //    return '../Assets/img/categories/' + image;
    //};
    debugger
    var categories = function () {
        //$http({
        //    method: 'GET',
        //    url: $rootScope.apiURL + 'Categories/All',
        //    headers: { 'Content-Type': 'application/json' },
        //    cache: false
        //}).then(function success(response) {
        //    var cat=[];
        //    $.each(response.data, function (key, item) {
        //        cat.push(item);
        //    });
        //    debugger
        //    return cat;
        //}, function error(response) {
        //});

       // $scope.gridOptions.data = categoryService.getAllCategories();

       $http(
                    {
                        method: 'GET',
                        url: $rootScope.apiURL + 'Categories/All'
                    })
               .then(
               function (response) {
                   debugger
                   if (response.data && response.data !== 'null' && response.data !== 'undefined') {
                       //$window.sessionStorage['userInfo'] = JSON.stringify(response.data);
                       $scope.gridOptions.data = response.data;
                   }
                   else {
                       console.log(response);
                   }
               }, function (error) {
                   console.log(errorMessage);
               });
        debugger
    };
    //var getcategories = function () {
    //    var deferred = $q.defer();
    //    $http({
    //        method: 'GET',
    //        url: $rootScope.apiURL + 'Categories/All'
    //    }).then(function success(response) {
    //        debugger
    //        categories = response.data;
    //        if ($rootScope.isLogging) {
    //            $log.log(response.data);
    //        }
    //        deferred.resolve(response.data);
    //    }, function error(response) {
    //        if ($rootScope.isLogging) {
    //            $log.log(response);
    //        }
    //        deferred.resolve(response);
    //    });
    //    return deferred.promise;
    //}
    //getcategories();



    //var getCategory = categoryService.getAllCategories()
    //           .then(function (result) {
    //               categories = result;
    //           }, function () {
    //               $scope.message = 'Incorrect email id or password entered. Please try again';
    //           });


    //var onSuccess = function (data, status, headers, config) {
    //    categories = data;
    //    if ($rootScope.isLogging) {
    //        $log.log(data);
    //    }
    //};

    //var onError = function (data, status, headers, config) {
    //    if ($rootScope.isLogging) {
    //        $log.log(status);
    //    }
    //}

    //var promise = $http.get($rootScope.apiURL + 'Categories/All').success(onSuccess).error(onError);

    //promise.success(onSuccess);
    //promise.error(onError);
    

    debugger
    $scope.gridOptions = {
        enableFiltering: true,
        data: categories(),
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        },
        columnDefs: [{ field: 'id', displayName: 'Id', enableFiltering: false, visible: false, enableFiltering: false, enableSorting: false },
                    { field: 'name', displayName: 'Category Name' },
                    { field: 'image', displayName: 'image' },
                     //{ field: 'image', displayName: 'image', enableFiltering: false, enableSorting: false, cellTemplate: '<img src="../Assets/img/categories/{{row.entity.image}}" />' },
                     { field: 'Edit', displayName: 'Edit', enableFiltering: false, enableSorting: false, cellTemplate: '<a href="#/addCategory/{{row.entity.id}}">Edit</a>' }]
    };
}]
);