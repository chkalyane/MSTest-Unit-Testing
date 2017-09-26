using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YesMed.API.Model;
using YesMed.Models;
using YesMed.Services;

namespace YesMed.API
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public HttpResponseMessage GetUser(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }

        [HttpPost]
        [ActionName("Validate")]
        public HttpResponseMessage ValidateUser(APILoginModel model)
        {
            var validuser = _userService.ValidateUser(model.UserName, model.Password);
            if (validuser == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Credentials");
            }
            return UserResponseMessage(ConvertToAPIUser(validuser));
        }

		[HttpPost]
		[ActionName("Register")]
		public HttpResponseMessage Register(UserModel model)
		{
			var user = _userService.Register(model);
			if (string.IsNullOrEmpty(user.UserName))
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to save the user");
			}
			return UserResponseMessage(ConvertToAPIUser(user));
		}
		[NonAction]
        private APILoginModel ConvertToAPIUser(UserModel user)
        {
            return new APILoginModel() { UserName = user.UserName};
        }

        [NonAction]
        private HttpResponseMessage UserResponseMessage(APILoginModel userViewModel)
        {
            var response = userViewModel != null ? Request.CreateResponse(HttpStatusCode.OK, userViewModel) :
                                        Request.CreateResponse<APILoginModel>(HttpStatusCode.NotFound, null);

            response.Headers.Location = userViewModel != null ? new Uri(Request.RequestUri.OriginalString) : null;
            response.Headers.ConnectionClose = true;

            return response;
        }
    }

}
