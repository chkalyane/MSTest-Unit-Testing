using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesMed.API.Model;
using YesMed.Common;
using YesMed.Models;

namespace YesMed.Services
{
    public interface IOrderService
    {
        GenericReturnArg CheckOut(OrderModel orderModel);
    }
}
