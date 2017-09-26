var yesMedApp = angular.module("yesMedModule", ['ui.router']).
config(function ($urlRouterProvider, $stateProvider) {

    $urlRouterProvider.otherwise('index');

    $stateProvider
       .state('index', {
           url: "",
           views: {
               "categories": {
                   url: 'views',
                   templateUrl: '/views/List.html',
                   controller: 'categoryCtrl'
               }
           }
       }).state('products', {
           url: '/products/:categoryId/:name',
           templateUrl: '/views/products.html',
           controller: 'productCtrl'
       }).state('cart', {
           url: '/cart',
           templateUrl: '/views/cart.html',
           controller: 'productCtrl'
       }).state('register', {
           url: '/register',
           templateUrl: '/views/_register.html',
           controller: 'loginCtrl'
       }).state('login', {
           url: '/login',
           templateUrl: '/views/_login.html',
           controller: 'loginCtrl'
       });
});

yesMedApp.filter('splitListFilter', function () {
    return function (data, chunk) {
        if (!data || data.length === 0) {
            return data;
        }

        var results = [];
        for (var i = 0, j = data.length; i < j; i += chunk) {
            results.push(data.slice(i, i + chunk));
        }

        if (!data.$$splitListFilter || !angular.equals(data.$$splitListFilter, results)) {
            data.$$splitListFilter = results;
        }
        return data.$$splitListFilter;
    };
});
yesMedApp.directive('isNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            element.bind("keydown keypress", function (event) {
                if (event.which === 32) {
                    event.returnValue = false;
                    return false;
                }
            });
            scope.$watch(attrs.ngModel, function (newValue, oldValue) {
                var arr = String(newValue).split("");
                if (arr.length === 0) return;
                if (arr.length === 1 && (arr[0] == '-' || arr[0] === '.')) return;
                if (arr.length === 2 && newValue === '-.') return;
                if (isNaN(newValue)) {
                    //scope.wks.number = oldValue;
                    ngModel.$setViewValue(oldValue);
                    ngModel.$render();
                }
            });
        }
    };
}).directive('editProductDialog', [function () {
    return {
        restrict: 'E',
        scope: {
            model: '=',
        },
        link: function (scope, element, attributes) {
            scope.$watch('model.visible', function (newValue) {
                var modalElement = element.find('.modal');
                modalElement.modal(newValue ? 'show' : 'hide');
            });

            element.on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = true;
                    $(this).modal("toggle")
                });
            });

            element.on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = false;
                });
            });
        },
        templateUrl: '/views/add-product-dialog.html',
    };
}]).directive('editLoginDialog', [function () {
    return {
        restrict: 'E',
        scope: {
            model: '=',
        },
        link: function (scope, element, attributes) {
            scope.$watch('model.visible', function (newValue) {
                var modalElement = element.find('.modal');
                modalElement.modal(newValue ? 'show' : 'hide');
            });
            element.on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = true;
                    $(this).modal("toggle")
                });
            });
            element.on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = false;
                });
            });
        },
        templateUrl: function (elem, attrs) {
            return attrs.template || '/views/_login.html';
        },
    };
}]).directive('editRegisterDialog', [function () {
    return {
        restrict: 'E',
        scope: {
            model: '=',
        },
        link: function (scope, element, attributes) {
            scope.$watch('model.visible', function (newValue) {
                var modalElement = element.find('.modal');
                modalElement.modal(newValue ? 'show' : 'hide');
            });
            element.on('shown.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = true;
                    $(this).modal("toggle")
                });
            });
            element.on('hidden.bs.modal', function () {
                scope.$apply(function () {
                    scope.model.visible = false;
                });
            });
        },
        templateUrl: function (elem, attrs) {
            return attrs.template || '/views/_register.html';
        },
    };
}]).directive('bindFile', [function () {
    return {
        require: "ngModel",
        restrict: 'A',
        link: function ($scope, el, attrs, ngModel) {
            el.bind('change', function (event) {
                ngModel.$setViewValue(event.target.files[0]);
                $scope.$apply();
            });
            
            $scope.$watch(function () {
                return ngModel.$viewValue;
            }, function (value) {
                if (!value) {
                    el.val("");
                }
            });
        }
    };
}]);
yesMedApp.filter('INR', function () {
    return function (input) {
        if (!isNaN(input)) {
            var currencySymbol = '₹';
            //var output = Number(input).toLocaleString('en-IN');   <-- This method is not working fine in all browsers!           
            var result = input.toString().split('.');

            var lastThree = result[0].substring(result[0].length - 3);
            var otherNumbers = result[0].substring(0, result[0].length - 3);
            if (otherNumbers != '')
                lastThree = ',' + lastThree;
            var output = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;

            if (result.length > 1) {
                output += "." + result[1];
            }

            return currencySymbol + output;
        }
    }
});
yesMedApp.run(['$rootScope', function ($rootScope) {
    $rootScope.apiURL = 'http://localhost:56647/YesMed/';
    $rootScope.basketCount = 0;
    $rootScope.$on('$routeChangeStart', function () {
        alert('refresh');
    });
}]);





