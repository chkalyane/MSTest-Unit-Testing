var yesMedAdmin = angular.module('YesMed', ['ngRoute', "ui.grid"]);
//$stateProvider, $urlRouterProvider,
yesMedAdmin.config(function ($routeProvider, $locationProvider) {

    $locationProvider.hashPrefix('');
    //// Gets the user information from the service.
    //function oAuth($q, userAccountService) {
    //    var userInfo = userAccountService.getUserInfo();
    //    if (userInfo) {
    //        return $q.when(userInfo);
    //    } else {
    //        return $q.reject({ authenticated: false });
    //    }
    //}

    ////$urlRouterProvider.otherwise('user');
    ////$stateProvider.state('user', {
    ////    url: '/user',
    ////    templateUrl: '/Areas/Admin/Views/User/User.html',
    ////    controller: 'userCtrl'
    ////})
    ////.state('addUser', {
    ////    url: '/addUser',
    ////    templateUrl: '/Areas/Admin/Views/User/AddUser.html',
    ////    controller: 'addUserCtrl'
    ////});

    //routeparamater
    $routeProvider
       .when('/', {
           templateUrl: "/Areas/Admin/Views/User/User.html",
           controller: 'userCtrl'
       })
        .when('/user', {
            templateUrl: "/Areas/Admin/Views/User/User.html",
            controller: 'userCtrl'
        })
        .when('/addUser', {
            templateUrl: "/Areas/Admin/Views/User/addUser.html",
            controller: 'addUserCtrl'
        })
        .when('/addUser/:Id', {
            templateUrl: "/Areas/Admin/Views/User/addUser.html",
            controller: 'addUserCtrl'
        })
        .when('/class', {
              templateUrl: "/Areas/Admin/Views/Class/class.html",
              controller: 'classCtrl'
          })
        .when('/addClass', {
            templateUrl: "/Areas/Admin/Views/Class/addClass.html",
            controller: 'addUserCtrl'
        })
         .when('/addClass/:Id', {
             templateUrl: "/Areas/Admin/Views/Class/addClass.html",
             controller: 'addUserCtrl'
         })
         .when('/category', {
             templateUrl: "/Areas/Admin/Views/Category/Category.html",
             controller: 'categoryCtrl'
         })
         .when('/addCategory', {
             templateUrl: "/Areas/Admin/Views/Category/addCategory.html",
             controller: 'addCategoryCtrl'
         })
        .when('/addCategory/:Id', {
            templateUrl: "/Areas/Admin/Views/Category/addCategory.html",
            controller: 'addCategoryCtrl'
        })
        .when('/type', {
            templateUrl: "/Areas/Admin/Views/Category/Type.html",
            controller: 'categoryCtrl'
        })
         .when('/addType', {
             templateUrl: "/Areas/Admin/Views/Category/addType.html",
             controller: 'addCategoryCtrl'
         })
        .when('/addType/:Id', {
            templateUrl: "/Areas/Admin/Views/Category/addType.html",
            controller: 'addCategoryCtrl'
        })
        .when('/products', {
            templateUrl: "/Areas/Admin/Views/Products/products.html",
            controller: 'productsCtrl'
        })
        .when('/addProducts', {
            templateUrl: "/Areas/Admin/Views/Products/addProducts.html",
            controller: 'addProductsCtrl'
        })
        .when('/addProducts/:Id', {
            templateUrl: "/Areas/Admin/Views/Products/addProducts.html",
            controller: 'addProductsCtrl'
        })
        .otherwise({ redirectTo: '/' });
});

//app.run(['$rootScope', '$state', 'userAccountService', function ($rootScope, $state, userAccountService) {
//    $rootScope.apiURL = 'http://10.71.12.108/SMPSWebAPI/api/';
//    //On State change startsthe below block will executed
//    $rootScope.$on('$stateChangeStart', function (event, toState) {
//        // Comparing current state with login
//        var isLogin = toState.name === 'login';
//        if (isLogin) {
//            return;
//        }
//        // Comparing userinfo object and on failure
//        // this will re-direct to login page
//        var userInfo = userAccountService.getUserInfo();
//        // for successful login user info must have some user details
//        if (userInfo === undefined) {
//            // stop current execution
//            event.preventDefault();
//            // State changes to login page
//            $state.go('login');
//        }
//    });
//    //On State change if errors occers Then the below block will executed
//    $rootScope.$on('$stateChangeError', function (event, current, previous, eventObj) {
//        if (eventObj.authenticated === false) {
//            // Changing the state from the current page to login page
//            $state.go('login');
//        }
//    });
//}]);

yesMedAdmin.run(['$rootScope', function ($rootScope) {
    $rootScope.apiURL = 'http://localhost:56647/YesMed/';
    $rootScope.isLogging = true;
}]);

yesMedAdmin.filter('replaceBackSlashWithFarwordSlash', function () {
    return function (input) {
        return input.replace(/\\/g, '/');
    };
});



