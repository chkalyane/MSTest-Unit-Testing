var EditLoginDialogModel = function () {
    this.visible = false;
};
EditLoginDialogModel.prototype.open = function () {
    this.visible = true;
};
EditLoginDialogModel.prototype.close = function () {
    this.visible = false;
};
var EditRegisterDialogModel = function () {
    this.visible = false;
};
EditRegisterDialogModel.prototype.open = function () {
    this.visible = true;
};
EditRegisterDialogModel.prototype.close = function () {
    this.visible = false;
};
yesMedApp.controller('loginCtrl', ['$scope', '$http', '$rootScope',
   function ($scope, $http, $rootScope) {
       $scope.editLoginDialog = new EditLoginDialogModel();
       $scope.editRegisterDialog = new EditRegisterDialogModel();
       $scope.register = function (name, userName, password, cPassword) {
           var userModel = {
               Name: name,
               UserName: userName,
               Password: password
           };
           $http({
               method: 'POST',
               data: userModel,
               url: $rootScope.apiURL + 'User/Register',
           }).then(function success(response) {
               var modal = $('#customModal');
               modal.find('.modal-title').text("Success");
               modal.find('.modal-body').text(response.data.message);
               modal.modal('show');
               DataService.cart.clearItems();
               $state.reload();
           }, function error(response) {
               var modal = $('#customModal');
               modal.find('.modal-title').text("Failed");
               modal.find('.modal-body').text(response.data.message);
               modal.modal('show');
           });
       };
   }]
);