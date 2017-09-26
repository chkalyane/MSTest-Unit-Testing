using YesMed.Models;

namespace YesMed.API.Model
{
    public class APIProductModel
    {
        #region Properties
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal OfferingDiscount { get; set; }

        public int ShippingCharges { get; set; }
        #endregion

        #region Ctors
        public APIProductModel()
        { }
        public APIProductModel(ProductModel model)
        {
            ID = model.ID;
            Name = model.Name;
            Image = model.ImageName + ".PNG";
            UnitPrice = model.UnitPrice;
            OfferingDiscount = model.OfferingDiscount;
            ShippingCharges = 50;
        }

        #endregion
    }
}
