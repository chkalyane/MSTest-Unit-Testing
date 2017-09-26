using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YesMed.Models
{
    public class CategoryModel
    {
        #region Properties

        public int ID { get; set; }

        public string Name { get; set; }

        public string ImageName { get; set; }

        public int ProductTypeID { get; set; }

        public List<ProductModel> Products { get; set; }
        #endregion

        #region Ctors

        public CategoryModel(int id, string name, string imgName, int productTypeID)
        {
            ID = id;
            Name = name;
            ImageName = imgName;
            ProductTypeID = productTypeID;
        }

        public void SetProducts(List<ProductModel> products)
        {
            Products = products;
        }
        #endregion
    }
}