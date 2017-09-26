(function () {
    yesMedAdmin.factory('categoryService', ['$http', '$rootScope', '$q', '$window', categoryService]);
    /* To validate the entred user emailid and password   */
    /* This method calls service to validate the given credntials */
    function categoryService($http, $rootScope, $q, $window) {
        var categories;
        function getAllCategories() {
            debugger
            var deferred = $q.defer();
            $http(
                    {
                        method: 'GET',
                        url: $rootScope.apiURL + 'Categories/All'
                    })
               .then(
               function (response) {
                   debugger
                   if (response.data && response.data !== 'null' && response.data !== 'undefined') {
                       $window.sessionStorage['userInfo'] = JSON.stringify(response.data);
                       categories = response.data;
                       deferred.resolve(categories);
                   }
                   else {
                       deferred.resolve(categories);
                   }
               }, function (error) {
                   deferred.reject(error);
               });
            return deferred.promise;
        }
        
        function getAllCattegories() {
            return categories;
        }
        return {
            getAllCategories: getAllCategories 
        };
    }
})();
// End of User Account Service.
