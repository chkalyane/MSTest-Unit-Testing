using System.Collections.Generic;
using System.Linq;
using YesMed.Data.Contexts;
using YesMed.Domain.Shared;
using YesMed.Models;

namespace YesMed.Services
{
    public class ProductService : IProductService
    {
        public readonly IEntityContext _entityContext;
        public ProductService(IEntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public ProductModel GetByID(int id)
        {
            var product = _entityContext.GetQueryable<Product>(_ => _.ID == id).SingleOrDefault();
            return product == null ? null : ConvertToProductModel(product);
        }

        public IEnumerable<ProductModel> GetAll(int pageSize = 10)
        {
           
            if ( pageSize > 0)
            return _entityContext.GetQueryable<Product>(_ => _.Active).Take(pageSize).ToList().Select(_ => ConvertToProductModel(_));
            else
                return _entityContext.GetQueryable<Product>(_ => _.Active).ToList().Select(_ => ConvertToProductModel(_));
        }

        public List<ProductModel> GetByCategoryID(int categoryID, int pageSize = 10)
        {

            var order = _entityContext.GetQueryable<Order>(_ => _.ID > 0).ToList();

            return _entityContext.GetQueryable<Product>(_ => _.Active).Where(_ => _.CategoryID == categoryID).Take(pageSize)
                .ToList().Select(_ => ConvertToProductModel(_)).ToList();
        }
      
        public ProductModel Add(ProductModel productModel)
        {
            _entityContext.Add(ConvertToProduct(productModel));
            _entityContext.Commit();
            return productModel;
        }

        public bool DeActivate(int id)
        {
            return false;
        }

        #region Private Methods

        private Product GetProduct(int id)
        {
            return _entityContext.GetQueryable<Product>(_ => _.ID == id).Single();
        }

        private Product ConvertToProduct(ProductModel productModel)
        {
            return new Product(productModel.Name,
             productModel.ImageName,
             productModel.ClassID,
             productModel.CompanyID,
             productModel.CategoryID,
             productModel.ProductTypeID,
             productModel.UnitPrice,
             productModel.OfferingDiscount,
             productModel.Margin,
             productModel.BatchNo,
             productModel.Composition,
             productModel.ManufacturingDate,
             productModel.ExpiryDate,
             productModel.UnitsInStack,
             productModel.UnitsInTransit,
             productModel.UnitsOnOrder,
             productModel.Comments,
             productModel.Active,
             productModel.CreatedOn,
             productModel.ModifiedOn,
             productModel.ModifiedBy, productModel.CreatedBy);
        }

        private ProductModel ConvertToProductModel(Product product)
        {
            return new ProductModel(product.ID, product.Name,
            product.Image,
            product.ClassID,
            product.CompanyID,
            product.CategoryID,
            product.ProductTypeID,
            product.UnitPrice,
            product.OfferingDiscount,
            product.Margin,
            product.BatchNo,
            product.Composition,
            product.ManufacturingDate,
            product.ExpiryDate,
            product.UnitsInStock,
            product.UnitsInTransit,
            product.UnitsOnOrder,
            product.Comments,
            product.Active,
            product.ModifiedOn,
            product.ModifiedBy);
        }

        #endregion
    }
}
