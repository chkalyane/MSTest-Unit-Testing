using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YesMed.API.Model;
using YesMed.Models;
using YesMed.Services;

namespace YesMed.API
{
    [RoutePrefix("YesMed")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private const int _defaultPageSize = 20;
        private string imagePath;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            imagePath = ConfigurationManager.AppSettings["ImageUrl"].ToString();
        }

        [Route("Category/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var category = _categoryService.GetByID(id);
            return category == null ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category doesn't exists") :
             CategoryResponseMessage(new List<APICategoryModel>() { new APICategoryModel(category, imagePath) });
        }

        [Route("Categories/All")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var categories = new List<APICategoryModel>()
            {
                new APICategoryModel() { ID = 1, Name = "Suppliments", Image ="FoodSuppliments"+".PNG"},
                 new APICategoryModel() { ID = 2, Name = "Injections", Image = "Injections"+".PNG"},
                  new APICategoryModel() { ID = 3, Name = "OrthoPedic", Image = "OrthoPedic"+".PNG"},
                   new APICategoryModel() { ID = 4, Name = "PainKillers", Image = "PainKillers"+".PNG"}
                   //new APICategoryModel() { ID = 5, Name = "SkinCare", Image = "SkinCare"+".PNG"}
            };
            return CategoryResponseMessage(categories);
            //var products = _productService.GetAll(_defaultPageSize);
            //if (!products.Any())
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            //}
            //return ProductResponseMessage(ConvertToAPIProducts(products.ToList()));
        }

        #region Private Method

        [NonAction]
        private List<APICategoryModel> ConvertToAPICategories(List<CategoryModel> categories)
        {
            return categories.Select(_ => new APICategoryModel(_, imagePath)).ToList();
        }

        [NonAction]
        private HttpResponseMessage CategoryResponseMessage(List<APICategoryModel> categories)
        {
            var response = categories.Any() ? Request.CreateResponse(HttpStatusCode.OK, categories) :
                                        Request.CreateResponse<APICategoryModel>(HttpStatusCode.NotFound, null);

            response.Headers.Location = categories.Any() ? new Uri(Request.RequestUri.OriginalString) : null;
            response.Headers.ConnectionClose = true;

            return response;
        }
        #endregion

    }
}