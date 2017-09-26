(function () {
    angular.module('YesMedapp').directive('yesmedProduct', function () {
        return {
            restrict: 'E',
            scope: { obj: '=' },
            template: '<div class="prod-cnt prod-box shadow cat-1"> <img src="img/product1.jpg"><div class="buy-ico"></div><h3><a href="#">{{obj.name}} </a></h3><div class="price-cnt"><div class="price old">$96.00</div><div class="price">$45.00</div></div><p>Donec id elit non mi porta gravida at eget metus. Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum nibh, ut fermentum massa justo sit amet risus. Etiam porta sem malesuada magna mollis euismod.</p></div>'
        };
    });
})();