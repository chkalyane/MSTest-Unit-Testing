var EditProductDialogModel = function () {
    this.visible = false;
};
EditProductDialogModel.prototype.open = function (product) {
    this.product = product;
    this.visible = true;
};
EditProductDialogModel.prototype.close = function () {
    this.visible = false;
};

yesMedApp.controller('productCtrl', ['$scope', '$http', '$rootScope', 'DataService', '$stateParams', '$window',
   function ($scope, $http, $rootScope, DataService, $stateParams, $window) {
       $scope.categoryID = $stateParams.categoryId;
       $scope.categoryName = $stateParams.name;
       $scope.editDialog = new EditProductDialogModel();
       $scope.prescriptionName = "";
       $scope.getImage = function (image) {
           return '../Assets/img/products/' + image;
       };
       $scope.getProducts = function () {
           $http({
               method: 'GET',
               url: $rootScope.apiURL + 'Categories/' + $scope.categoryID + '/products',
           }).then(function success(response) {
               $scope.products = response.data;
           }, function error(response) {
           });
       };
       $scope.getProduct = function (id) {
           for (var i = 0; i < this.products.length; i++) {
               if (this.products[i].id == id)
                   return this.products[i];
           }
           return null;
       }
       $scope.cart = DataService.cart;
       $rootScope.basketCount = DataService.cart.getTotalCount();
       $scope.cart = DataService.cart;
       $scope.showAlert = function (isSuccess, message) {
           var modal = $('#customModal');
           modal.find('.modal-title').text(isSuccess);
           modal.find('.modal-body').text(message);
           modal.modal('show');
       };
       $scope.uploadPrescription = function (prescription) {
           var formData = new FormData();
           formData.append("Prescription", prescription);
           $http.post($rootScope.apiURL + 'Order/UploadPrescription', formData, {
               transformRequest: angular.identity,
               headers: { 'Content-Type': undefined }
           }).then(function success(response) {
               $scope.prescriptionName = response.data;
               $scope.showAlert('Success', "File uploaded successfully")
           }, function error(response) {
               $scope.showAlert('Failed', "Failed to save the prescription, please try again")
           });
       };
       $scope.checkOut = function (mrp, discount, cartTotal, shippingCharges, prescription) {
           if ($scope.prescriptionName == null || $scope.prescriptionName === "") {
               $scope.showAlert('Failed', "Please upload the prescription and continue")
               return false;
           }
           var orderModel = {
               MRP: mrp,
               DiscountOnBagItems: discount,
               CartTotal: cartTotal,
               ShippingCharges: shippingCharges,
               Products: JSON.parse(localStorage["AngularStore_items"]),
               PrescriptionName: $scope.prescriptionName
           };

           $http({
               method: 'POST',
               data: orderModel,
               url: $rootScope.apiURL + 'Order/CheckOut',
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
   }]);
yesMedApp.factory("DataService", function () {
    var myCart = new shoppingCart("AngularStore");
    return {
        cart: myCart
    };
});
