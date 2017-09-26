
using System.Collections.Generic;
using YesMed.API.Model;
using YesMed.Models;

namespace YesMed.Services
{
    public interface IUserService
    {
        UserModel Register(UserModel usermodel);

        UserModel ValidateUser(string email, string password);

        UserModel GetUser(string userName);

		bool Delete(string userName);

		bool Update(APIUserModel usermodel);

        List<UserModel> GetAll(int pageSize = 10);
    }
}
