function shoppingCart(cartName) {
    this.cartName = cartName;
    this.clearCart = false;
    this.checkoutParameters = {};
    this.items = [];

    this.loadItems();

    var self = this;
    $(window).unload(function () {
        if (self.clearCart) {
            self.clearItems();
        }
        self.saveItems();
        self.clearCart = false;
    });
}
shoppingCart.prototype.loadItems = function () {
    var items = localStorage != null ? localStorage[this.cartName + "_items"] : null;
    if (items != null && JSON != null) {
        try {
            var items = JSON.parse(items);
            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                if (item.id != null && item.name != null && item.price != null && item.quantity != null) {
                    item = new cartItem(item.id, item.name, item.price, item.quantity, item.discount, item.shippingCharges);
                    this.items.push(item);
                }
            }
        }
        catch (err) {
            // ignore errors while loading...
        }
    }
}
shoppingCart.prototype.saveItems = function () {
    if (localStorage != null && JSON != null) {
        localStorage[this.cartName + "_items"] = JSON.stringify(this.items);
    }
}

shoppingCart.prototype.addItem = function (id, name, price, quantity, discount, shippingCharges) {
    quantity = this.toNumber(quantity);
    if (quantity != 0) {
        var found = false;
        for (var i = 0; i < this.items.length && !found; i++) {
            var item = this.items[i];
            if (item.id == id) {
                found = true;
                item.quantity = this.toNumber(item.quantity + quantity);
                if (item.quantity <= 0) {
                    this.items.splice(i, 1);
                }
            }
        }
        if (!found) {
            var item = new cartItem(id, name, price, quantity, discount, shippingCharges);
            this.items.push(item);
        }
        this.saveItems();
    }
}
shoppingCart.prototype.getTotalUnitPrice = function (id) {
    var total = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (id == null || item.id == id) {
            total += this.toNumber(item.quantity * item.price);
        }
    }
    return total;
}
shoppingCart.prototype.getTotalDiscount = function (id) {
    var total = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (id == null || item.id == id) {
            total += this.toNumber(item.quantity * item.discount);
        }
    }
    return total;
}

shoppingCart.prototype.getShippingCharges = function () {
    var item = this.items[0];
    return item.shippingCharges;
}
shoppingCart.prototype.getTotalCount = function (id) {
    var count = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (id == null || item.id == id) {
            //count += this.toNumber(item.quantity);
            count += 1;
        }
    }
    return count;
}

shoppingCart.prototype.getTotalNoOfItems = function (id) {
    var count = 0;
    for (var i = 0; i < this.items.length; i++) {
        var item = this.items[i];
        if (id == null || item.id == id) {
            count += this.toNumber(item.quantity);
        }
    }
    return count;
}

shoppingCart.prototype.clearItems = function () {
    this.items = [];
    this.saveItems();
    
}

shoppingCart.prototype.addCheckoutParameters = function (serviceName, merchantID, options) {
    if (serviceName != "PayPal" && serviceName != "Google") {
        throw "serviceName must be 'PayPal' or 'Google'.";
    }
    if (merchantID == null) {
        throw "A merchantID is required in order to checkout.";
    }
    this.checkoutParameters[serviceName] = new checkoutParameters(serviceName, merchantID, options);
}
shoppingCart.prototype.addFormFields = function (form, data) {
    if (data != null) {
        $.each(data, function (name, value) {
            if (value != null) {
                var input = $("<input></input>").attr("type", "hidden").attr("name", name).val(value);
                form.append(input);
            }
        });
    }
}
shoppingCart.prototype.toNumber = function (value) {
    value = value * 1;
    return isNaN(value) ? 0 : value;
}
function checkoutParameters(serviceName, merchantID, options) {
    this.serviceName = serviceName;
    this.merchantID = merchantID;
    this.options = options;
}
function cartItem(id, name, price, quantity, discount, shippingCharges) {
    this.id = id;
    this.name = name;
    this.price = price * 1;
    this.quantity = quantity * 1;
    this.discount = discount;
    this.shippingCharges = shippingCharges;
}

