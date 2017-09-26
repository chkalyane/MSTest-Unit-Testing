using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesMed.Models;

namespace YesMed.Services
{
    public interface IProductService
    {
       ProductModel GetByID(int id);

       ProductModel Add(ProductModel productModel);

       IEnumerable<ProductModel> GetAll(int pageSize = 10);

        List<ProductModel> GetByCategoryID(int categoryID, int pageSize = 10);

       bool DeActivate(int id);
    }
}
