using System.Net;
using System.Net.Http;
using System.Web.Http;
using YesMed.API.Model;
using YesMed.Models;
using YesMed.Services;

namespace YesMed.API
{
    public class AdminUserController : ApiController
    {
        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public HttpResponseMessage GetUser(string userName)
        {
            var users = _userService.GetUser(userName);
            if (users == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User NotFound");
            }
            return Request.CreateResponse(HttpStatusCode.OK, ConvertToAPIUserModel(users));
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var users = _userService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [NonAction]
        private APILoginModel ConvertToAPIUser(UserModel user)
        {
            return new APILoginModel() { UserName = user.UserName};
        }

        [NonAction]
        private APIUserModel ConvertToAPIUserModel(UserModel user)
        {
            return new APIUserModel() { UserName = user.UserName, Password = user.Password, UserTypeId = user.UserTypeId };
        }
        [NonAction]
        private UserModel ConvertAPIUserModelToUserModel(APIUserModel user)
        {
            return new UserModel() { Name = user.Name, UserName = user.UserName, Password = user.Password, UserTypeId = (user.UserTypeId ==0 ) ? user.UserTypeId : 1 };
        }

        [HttpPost]
        [ActionName("UpdateUser")]
        public HttpResponseMessage UpdateUser(APIUserModel model)
        {
            // return Request.CreateResponse(HttpStatusCode.OK);

            // _userService.GetUser(model.ID).
            dynamic userStatus;
            if (model.ID > 0)
            {
                userStatus = _userService.Update(model);
            }
            else
            {
                userStatus = _userService.Register(ConvertAPIUserModelToUserModel(model));
            }
 
            if (userStatus == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User NotFound");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("DeleteUser/{userId:int}")]
        public HttpResponseMessage DeleteUser(string userName)
        {
            bool userStatus = _userService.Delete(userName);
            if (!userStatus)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User NotFound To Delete");
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }

}
