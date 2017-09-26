angular.module('YesMed').controller('addProductsCtrl', ['$scope', '$rootScope', '$routeParams', '$http', '$log', function ($scope, $rootScope, $routeParams, $http, $log) {
    debugger


    var productId = $routeParams.Id;
    $scope.getImage = function (image) {
        
        debugger
        image = "/Assets/img/products/" + image;
        return image.replace(/\\/g, '/');
    };
    if ($routeParams.Id == undefined) {
        $scope.product = { id: 0, name: "", image: "", classID: "1", companyID: "1", categoryID: "1", productTypeID : "1"};
    }
    else
    {
        $http.get($rootScope.apiURL + 'AdminProducts/' + productId)
        .then(function (response) {
            debugger
            $scope.product = response.data[0];
            if ($rootScope.isLogging) {
                $log.log(response.data[0]);
                    }
        }, function (errorMessage) {
            console.log(errorMessage);
        });
    }

    $scope.UpdateProduct = function (product)
    {
        debugger
        $http.post($rootScope.apiURL + 'Products/UpdateProd/', $scope.product)
       .then(function (response) {
           if ($rootScope.isLogging) {
               $log.log(response.data);
           }
       }, function (errorMessage) {
           console.log(errorMessage);
       });
    }

    // GET THE FILE INFORMATION.
    $scope.getFileDetails = function (e) {

        $scope.files = [];
        $scope.$apply(function () {

            // STORE THE FILE OBJECT IN AN ARRAY.
            for (var i = 0; i < e.files.length; i++) {
                $scope.files.push(e.files[i])
            }

        });
    };

    $scope.uploadFiles = function () {

        //FILL FormData WITH FILE DETAILS.
        var data = new FormData();
        debugger
        for (var i in $scope.files) {
            data.append("uploadedFile", $scope.files[i]);
        }

        data.append("productName", $scope.product.name);

        // ADD LISTENERS.
        var objXhr = new XMLHttpRequest();
        objXhr.addEventListener("progress", updateProgress, false);
        objXhr.addEventListener("load", transferComplete, false);

        // SEND FILE DETAILS TO THE API.
        objXhr.open("POST", $rootScope.apiURL + 'AdminProducts/UploadImage/');
        objXhr.send(data);
    }

    // UPDATE PROGRESS BAR.
    function updateProgress(e) {
        if (e.lengthComputable) {
            document.getElementById('pro').setAttribute('value', e.loaded);
            document.getElementById('pro').setAttribute('max', e.total);
        }
    }

    // CONFIRMATION.
    function transferComplete(e) {
        alert("Files uploaded successfully.");
    }
}]);

