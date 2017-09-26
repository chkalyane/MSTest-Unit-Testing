using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using YesMed.API.Model;
using YesMed.Data.Contexts;
using YesMed.Domain.Shared;
using YesMed.Models;

namespace YesMed.Services
{
	public class UserService : IUserService
	{
		public readonly IEntityContext _entityContext;
		public UserService(IEntityContext entityContext)
		{
			_entityContext = entityContext;
		}
		public UserModel Register(UserModel userModel)
		{
			ValidateUser(userModel.UserName, userModel.Password);
			var user = _entityContext.GetQueryable<User>(_ => _.UserName == userModel.UserName).SingleOrDefault();
			if (user == null)
			{
				_entityContext.Add(new User(userModel.Name, userModel.UserName, AESCryp.Encrypt(userModel.Password), userModel.UserTypeId));
				_entityContext.Commit();
			}
			else
				return null;
			return userModel;
		}

		public UserModel ValidateUser(string userName, string password)
		{
			var user = _entityContext.GetQueryable<User>(_ => _.UserName == userName).SingleOrDefault();
			if (user == null)
				return null;
			var ss = (AESCryp.Decrypt(user.Password) == password);
			return (AESCryp.Decrypt(user.Password) == password) ? new UserModel(user.Name, user.UserName, user.Type) : null;
		}

		public List<UserModel> GetAll(int pageSize = 10)
		{
			if (pageSize > 0)
				return _entityContext.GetQueryable<User>(_ => !string.IsNullOrEmpty(_.UserName)).Take(pageSize).ToList().Select(_ => ConvertToUserModel(_)).ToList();
			else
				return _entityContext.GetQueryable<User>(_ => !string.IsNullOrEmpty(_.UserName)).ToList().Select(_ => ConvertToUserModel(_)).ToList();
		}

		private UserModel ConvertToUserModel(User user)
		{
			return new UserModel(user.Name, user.UserName, user.Type);
		}

		public UserModel GetUser(string userName)
		{
			var user = _entityContext.GetQueryable<User>(_ => _.UserName == userName).Where(_ => _.UserName == userName).SingleOrDefault();

			return user == null ? null : new UserModel(user.Name, user.UserName, user.Type);
		}

		public bool Delete(string userName)
		{
			bool retStatus = false;
			try
			{
				_entityContext.Delete<User>(_entityContext.GetQueryable<User>(_ => _.UserName == userName).Where(_ => _.UserName == userName).Single());
				_entityContext.Commit();
				retStatus = true;
			}
			catch (Exception ex)
			{
				retStatus = false;
			}
			return retStatus;
		}

		public bool Update(APIUserModel usermodel)
		{
			bool retStatus = false;
			try
			{
				var userobj = _entityContext.GetQueryable<User>(_ => _.UserName == usermodel.UserName).Where(_ => _.UserName == usermodel.UserName).Single();
				userobj.UpdateUser(usermodel.Name, usermodel.UserName, AESCryp.Encrypt(usermodel.Password), usermodel.UserTypeId);
				_entityContext.Commit();
				retStatus = true;
			}
			catch (Exception)

			{
				retStatus = false;
			}
			return retStatus;
		}

	}
}
