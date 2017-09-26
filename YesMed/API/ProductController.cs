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
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private const int _defaultPageSize = 20;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("Products/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var product = _productService.GetByID(id);
            return product == null ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product doesn't exists") :
             ProductResponseMessage(new List<APIProductModel>() { new APIProductModel(product) });
        }

        [Route("Products/All")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
        //    var products = new List<APIProductModel>()
        //    {
        //        new APIProductModel() { ID = 1, Name = "Dolo650", Image = "Dolo650"+".PNG", OfferingDiscount = 200, UnitPrice = 500, ShippingCharges=50 },
        //         //new APIProductModel() { ID = 2, Name = "Crosin", Image = "Crosin"+".PNG", OfferingDiscount = 200, UnitPrice = 500, ShippingCharges=50 },
        //         // new APIProductModel() { ID = 3, Name = "MultiVit", Image ="MultiVit"+".PNG", OfferingDiscount = 200, UnitPrice = 500, ShippingCharges=50  },
        //         //  new APIProductModel() { ID = 4, Name = "Punarvit", Image = "Punarvit"+".PNG", OfferingDiscount = 200, UnitPrice = 500, ShippingCharges=50  },
        //         //   new APIProductModel() { ID = 5, Name = "StarVit", Image = "StarVit"+".PNG", OfferingDiscount = 200, UnitPrice = 500, ShippingCharges=50  },
        //             new APIProductModel() { ID = 6, Name = "ZoFen", Image = "ZoFen"+".PNG", OfferingDiscount = 200, UnitPrice = 500 , ShippingCharges=50 }
        //    };
        //    return ProductResponseMessage(products);
            var products = _productService.GetAll(_defaultPageSize);
            if (!products.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            }
            return ProductResponseMessage(ConvertToAPIProducts(products.ToList()));
        }


        [Route("Categories/{categoryId}/products")]
        [HttpGet]
        public HttpResponseMessage GetByCategory(int categoryID)
        {
            var products = _productService.GetByCategoryID(categoryID, _defaultPageSize);
            if (!products.Any())
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            return ProductResponseMessage(ConvertToAPIProducts(products.ToList()));
        }


        #region Private Method

        [NonAction]
        private List<APIProductModel> ConvertToAPIProducts(List<ProductModel> products)
        {
            return products.Select(_ => new APIProductModel(_)).ToList();
        }

        [NonAction]
        private HttpResponseMessage ProductResponseMessage(List<APIProductModel> products)
        {
            var response = products.Any() ? Request.CreateResponse(HttpStatusCode.OK, products) :
                                        Request.CreateResponse<APILoginModel>(HttpStatusCode.NotFound, null);

            response.Headers.Location = products.Any() ? new Uri(Request.RequestUri.OriginalString) : null;
            response.Headers.ConnectionClose = true;

            return response;
        }
        #endregion

    }
}