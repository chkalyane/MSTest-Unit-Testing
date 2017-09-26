using System;
using System.Collections.Generic;
using System.Web;
using YesMed.API.Model;

namespace YesMed.Models
{
    public class OrderModel
    {
        public List<APIProductModel> Products { get; set; }
        public Decimal MRP { get; set; }
        public Decimal DiscountOnBagItems { get; set; }
        public Decimal CartTotal { get; set; }
        public int PaymentType { get; set; }
        public Decimal ShippingCharges { get; set; }
        public string PrescriptionName { get; set; }
        public OrderModel()
        {

        }
    }
}