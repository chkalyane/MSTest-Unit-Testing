using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace YesMed.Models
{
    public class ProductModel
    {
        #region Properties

        public int ID { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int ClassID { get; set; }

        public int CompanyID { get; set; }

        public int CategoryID { get; set; }

        public int ProductTypeID { get; set; }

        public Decimal UnitPrice { get; set; }

        public Decimal OfferingDiscount { get; set; }

        public Decimal Margin { get; set; }

        public string BatchNo { get; set; }

        public string Composition { get; set; }

        public DateTime ManufacturingDate { get; set; }

        public DateTime ExpiryDate { get; set; }

        public int UnitsInStack { get; set; }

        public int UnitsInTransit { get; set; }

        public int UnitsOnOrder { get; set; }

        public string Comments { get; set; }

        public bool Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? ModifiedBy { get; set; }

        public int CreatedBy { get; set; }

        public int CartQuantity { get; set; }

        #endregion

        #region Ctors

        public ProductModel()
        {
            CartQuantity = 1;
        }
        public ProductModel(int id, string name, string imageName, decimal unitPrice):this()
        {
            ID = id;
            Name = name;
            ImageName = imageName;
            UnitPrice = unitPrice;
        }
        public  ProductModel(int id, string name, string imageName, int classID, int companyID, int categoryID, int productTypeID,
            Decimal unitPrice, decimal offeringDiscount, decimal margin, string batchNo, string composition, DateTime manufacturingDate,
            DateTime expiryDate, int unitsInStack, int unitsInTransit,
            int unitsOnOrder, string comments, bool active, DateTime? modifiedOn, int? modifiedBy)
        {
            ID = id;
            Name = name;
            ImageName = imageName;
            ClassID = classID;
            CompanyID = companyID;
            CategoryID = categoryID;
            ProductTypeID = productTypeID;
            UnitPrice = unitPrice;
            OfferingDiscount = offeringDiscount;
            Margin = margin;
            BatchNo = batchNo;
            Composition = composition;
            ManufacturingDate = manufacturingDate;
            ExpiryDate = expiryDate;
            UnitsInStack = unitsInStack;
            UnitsInTransit = unitsInTransit;
            UnitsOnOrder = unitsOnOrder;
            Comments = comments;
            Active = active;
            ModifiedOn = modifiedOn;
            ModifiedBy = modifiedBy;
          
        }
        #endregion
    }
}