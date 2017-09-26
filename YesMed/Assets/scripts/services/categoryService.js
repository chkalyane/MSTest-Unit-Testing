//angular.module('yesMedModule').factory('categoryService', ['$http', '$rootScope', '$q', '$window', categoryService]);
//function categoryService($http, $rootScope, $q, $window) {
//    var categories;
//    function getCategories() {
//        var deferred = $q.defer();
//        $http(
//                {
//                    method: 'GET',
//                    url: $rootScope.apiURL + 'Categories/All'
//                })
//           .then(
//           function (response) {
//               if (response.data && response.data !== 'null' && response.data !== 'undefined') {
//                   categories = response.data;
//                   deferred.resolve(categories);
//               }
//               else {
//                   console.log("error");
//                   deferred.resolve(categories);
//               }
//           }, function (error) {
//               console.log("error");
//               deferred.reject(error);
//           });
//        return deferred.promise;
//    }
//    return {
//        getCategories: getCategories
//    };
//}
