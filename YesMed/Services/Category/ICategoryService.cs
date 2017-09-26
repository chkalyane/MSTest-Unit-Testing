using System.Collections.Generic;
using YesMed.Models;

namespace YesMed.Services
{
    public interface ICategoryService
    {
        CategoryModel GetByID(int id);
        CategoryModel Add(CategoryModel productModel);
        List<CategoryModel> GetAll(int pageSize);
        bool DeActivate(int id);
    }
}
