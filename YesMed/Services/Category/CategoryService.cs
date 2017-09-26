using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using YesMed.Data.Contexts;
using YesMed.Domain.Shared;
using YesMed.Models;

namespace YesMed.Services
{
    public class CategoryService : ICategoryService
    {
        public readonly IEntityContext _entityContext;
        public readonly string _imagePath;
        public CategoryService(IEntityContext entityContext)
        {
            _entityContext = entityContext;
            _imagePath = ConfigurationManager.AppSettings["ImageUrl"].ToString();
        }

        public CategoryModel GetByID(int id)
        {
            var category = _entityContext.GetQueryable<Category>(_ => _.ID == id).Where(_=>_.ID == id).SingleOrDefault();
            return category == null ? null : ConvertToCategoryModel(category);
        }

        public List<CategoryModel> GetAll(int pageSize)
        {
            return _entityContext.GetQueryable<Category>(_ => _.Active).Take(pageSize).ToList().Select(_ => ConvertToCategoryModel(_)).ToList();
        }

        public IEnumerable<CategoryModel> GetAllByCategoryID(int pageSize, int productTypeID)
        {
            return _entityContext.GetQueryable<Category>(_ => _.Active && _.ID == productTypeID).Take(pageSize).ToList().Select(_ => ConvertToCategoryModel(_));
        }

        public CategoryModel Add(CategoryModel productModel)
        {
            _entityContext.Add(ConvertToCategory(productModel));
            _entityContext.Commit();
            return productModel;
        }

        public bool DeActivate(int id)
        {
            return false;
        }

        #region Private Methods

        private Category ConvertToCategory(CategoryModel categoryModel)
        {
            return new Category(categoryModel.Name, categoryModel.ImageName, categoryModel.ProductTypeID, true, System.DateTime.Now, 1, 1, System.DateTime.Now);
        }

        private CategoryModel ConvertToCategoryModel(Category category)
        {
            return new CategoryModel(category.ID, category.Name, Path.Combine(_imagePath, "categories", category.Image + ".PNG"), category.ProductTypeID);
        }

        #endregion
    }
}
