$(document).ready(function () {
    $('#myCarousel').carousel({
        interval: 1000 * 10
    });
    $('#discountCarousel').carousel({
        interval: 1000 * 10
    });
    $('#topSellingCarousel').carousel({
        interval: 1000 * 5
    })
});

yesMedApp.controller('categoryCtrl', ['$scope', '$http', '$rootScope',
   function ($scope, $http, $rootScope) {
       $scope.getImage = function (image) {
           return '../Assets/img/categories/' + image;
       };
       $scope.getcategories = function () {
           $http({
               method: 'GET',
               url: $rootScope.apiURL + 'Categories/All',
           }).then(function success(response) {
               $scope.categories = response.data;
           }, function error(response) {
           });
       };
       $scope.tabs = [{
           title: 'One',
           url: 'one.tpl.html'
       }, {
           title: 'Two',
           url: 'two.tpl.html'
       }, {
           title: 'Three',
           url: 'three.tpl.html'
       }];

       $scope.currentTab = 'one.tpl.html';

       $scope.onClickTab = function (tab) {
           $scope.currentTab = tab.url;
       }

       $scope.isActiveTab = function (tabUrl) {
           return tabUrl == $scope.currentTab;
       }
   }]
);
