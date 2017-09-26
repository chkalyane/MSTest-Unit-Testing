//(function () {
//    angular.module('yesMedapp').controller('userCtrl', ['$scope', 'userAccountService', function ($scope, userAccountService) {
//        $scope.userObject = { email: '', password: '' };
//        $scope.Validate = function () {
//            var postData = { email: $scope.email, password: $scope.password };
//            $http({
//                method: 'POST',
//                url: 'http://localhost:56647/API/User/Validate',
//                data: postData
//            }).then(function success(response) {
//                alert('success');
//            }, function error(response) {

//            });
//        }
//        $scope.login = function () {
//            $scope.errorFlag = false;
//            userAccountService.authenticateUser($scope.userObject)
//                .then(function (result) {
//                    $scope.userObject = result;
//                    $state.go('home');
//                }, function () {
//                    $scope.errorFlag = true;
//                    $scope.message = 'Incorrect email id or password entered. Please try again';
//                });
//        };
//    }]);
//})();
