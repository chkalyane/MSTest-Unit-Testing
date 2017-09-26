(function () {
    angular.module('yesMedModule').factory('userService', ['$http', '$rootScope', '$q', '$window', userAccountService]);
    function userAccountService($http, $rootScope, $q, $window) {
        var userProfile;
        function authenticateUser(userObject) {
            var deferred = $q.defer();
            $http(
                    {
                        method: 'GET',
                        url: $rootScope.apiURL + 'UserAccount/ValidateUser?userId='
                                + userObject.userName + '&password='
                                + userObject.password
                    })
               .then(
               function (response) {
                   if (response.data && response.data !== 'null' && response.data !== 'undefined') {
                       $window.sessionStorage['userInfo'] = JSON.stringify(response.data);
                       userProfile = response.data;
                       deferred.resolve(userProfile);
                   }
                   else {
                       console.log("error");
                       deferred.resolve(userProfile);
                   }
               }, function (error) {
                   console.log("error");
                   deferred.reject(error);
               });
            return deferred.promise;
        }
        function getUserInfo() {
            return userProfile;
        }
        function init() {
            if ($window.sessionStorage['userInfo']) {
                userProfile = JSON.parse($window.sessionStorage['userInfo']);
            }
        }
        init();
        return {
            authenticateUser: authenticateUser,
            getUserInfo: getUserInfo
        };
    }
})();
