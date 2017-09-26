using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YesMed.API.Model;
using YesMed.Models;
using YesMed.Services;

namespace YesMed.API
{
    [RoutePrefix("YesMed")]
    public class AdminProductController : ApiController
    {
        private readonly IProductService _productService;
        private const int _defaultPageSize = 20;

        public AdminProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("AdminProducts/{id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var product = _productService.GetByID(id);
            return product == null ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product doesn't exists") :
             ProductResponseMessage(new List<APIProductModel>() { new APIProductModel(product) });
        }

        [Route("AdminProducts/All")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //var products = new List<APIProductModel>()
            //{
            //    new APIProductModel() { ID = 1, Name = "Dolo650", Image = "Dolo650"+".PNG", OfferingDiscount = 200, UnitPrice = 500 },
            //     new APIProductModel() { ID = 2, Name = "Crosin", Image = "Crosin"+".PNG", OfferingDiscount = 200, UnitPrice = 500 },
            //      new APIProductModel() { ID = 3, Name = "MultiVit", Image ="MultiVit"+".PNG", OfferingDiscount = 200, UnitPrice = 500 },
            //       new APIProductModel() { ID = 4, Name = "Punarvit", Image = "Punarvit"+".PNG", OfferingDiscount = 200, UnitPrice = 500 },
            //        new APIProductModel() { ID = 5, Name = "StarVit", Image = "StarVit"+".PNG", OfferingDiscount = 200, UnitPrice = 500 },
            //         new APIProductModel() { ID = 6, Name = "ZoFen", Image = "ZoFen"+".PNG", OfferingDiscount = 200, UnitPrice = 500 }
            //};
            //return ProductResponseMessage(products);
            var products = _productService.GetAll(_defaultPageSize);
            if (!products.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            }
            return ProductResponseMessage(ConvertToAPIProducts(products.ToList()));
        }

        [Route("AdminProducts/GetAllProducts")]
        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            var products = _productService.GetAll();
            if (!products.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            }
            return ProductResponseMessage(ConvertToAPIProducts(products.ToList()));
        }

        [Route("AdminProducts/UploadImage")]
        [HttpPost]
        public HttpResponseMessage UploadImage()
        {
            int iUploadedCnt = 0;
            // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Assets/img/products/");

            HttpFileCollection hfc = HttpContext.Current.Request.Files;

            // CHECK THE FILE COUNT.
            for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
            {
                HttpPostedFile hpf = hfc[iCnt];

                if (hpf.ContentLength > 0)
                {
                    // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                    if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                    {
                        // SAVE THE FILES IN THE FOLDER.
                        hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                        iUploadedCnt = iUploadedCnt + 1;
                    }
                }
                ProductModel productModel = new ProductModel();
                productModel.ImageName = hpf.FileName;
                productModel.Name = HttpContext.Current.Request.Form["productName"];


                // productModel.Name = HttpContext.Current.Request.Form;
                var products = _productService.Add(productModel);
            }



            return new HttpResponseMessage(HttpStatusCode.Accepted);
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