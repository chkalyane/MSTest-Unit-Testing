using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using YesMed.Models;
using YesMed.Services;

namespace YesMed.API
{
    [RoutePrefix("YesMed")]
    public class OrderController : ApiController
    {
        private readonly IOrderService _orderService;
        private const int _defaultPageSize = 20;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public HttpResponseMessage UploadPrescription()
        {
           HttpFileCollection hfc = HttpContext.Current.Request.Files;
            try
            {
                var filePath = System.Web.Hosting.HostingEnvironment.MapPath("~/prescriptions/");
                HttpFileCollection fileCollection = HttpContext.Current.Request.Files;
                HttpPostedFile postedFile = fileCollection[0];
                var customFileName = Guid.NewGuid() + Path.GetFileName(postedFile.FileName);
                if (postedFile.ContentLength > 0)
                {
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    if (!File.Exists(filePath + customFileName))
                        postedFile.SaveAs(filePath + customFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK, customFileName);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Order/CheckOut")]
        [HttpPost]
        public HttpResponseMessage CheckOut(OrderModel orderModel)
        {
            var result = _orderService.CheckOut(orderModel);
            if (result.IsSucceed)
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Order placed sucessfully");
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, result.Message);
        }
    }
}