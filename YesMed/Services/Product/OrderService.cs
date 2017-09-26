using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using YesMed.API.Model;
using YesMed.Common;
using YesMed.Data.Contexts;
using YesMed.Domain.Shared;
using YesMed.Models;
using YesMed.Helpers;

namespace YesMed.Services
{
    public class OrderService : IOrderService
    {
        public readonly IEntityContext _entityContext;
        public OrderService(IEntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public GenericReturnArg CheckOut(OrderModel orderModel)
        {
            bool isValid = true;
            var productsOutOfStock = new List<string>();
            try
            {
                var checkoutProducts = new List<Product>();
                using (var scope = _entityContext.GetTransactionScope(TransactionScopeOption.RequiresNew,
                new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    var order = new Order(orderModel.MRP, orderModel.DiscountOnBagItems, orderModel.CartTotal, 1, orderModel.ShippingCharges, 1);
                    foreach (var model in orderModel.Products)
                    {
                        var product = GetProduct(model.ID);
                        if (ValidateCartProduct(product, model))
                        {
                            var orderDetail = new OrderDetails(product.ID, product.UnitPrice, model.Quantity, product.OfferingDiscount);
                            order.AddOrderDetails(orderDetail);
                        }
                        else {
                            isValid = false;
                            productsOutOfStock.Add(product.Name);
                        }
                    }
                    if (isValid)
                    {
                        _entityContext.Add(order);
                        _entityContext.Commit();
                        scope.Complete();
                    }
                    else
                        return new GenericReturnArg("products : " + productsOutOfStock.ToDelimitedString(", ") + " " + "are out of stock, please remove and continue", false);
                }
                return new GenericReturnArg();
            }
            catch (Exception ex)
            {
                return new GenericReturnArg("Falied to process the order, please try again", false);
            }
        }
        private Product GetProduct(int id)
        {
            return _entityContext.GetQueryable<Product>(_ => _.ID == id).Single();
        }
        private bool ValidateCartProduct(Product product, APIProductModel model)
        {
            return ((product.UnitsInStock + product.UnitsInTransit - product.UnitsOnOrder) >= model.Quantity);
        }
    }
}