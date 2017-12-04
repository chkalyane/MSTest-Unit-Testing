
using UnitTestDemoUI.Models;
using UnitTestDemoUI.Repository;
using System;

namespace Services
{
    public class UserService : IUserService
    {

        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Add(User user)
        {
            try
            {
                return _userRepository.Add(user);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

		public User Get(int userID)
		{
			return _userRepository.Get(userID);
		}

		public bool Delete(User user)
        {
            return _userRepository.Delete(user);
        }

    }
}
