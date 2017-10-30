
using ServiceExample.Models;
using ServiceExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {

        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(User user)
        {
            try
            {
                return _userRepository.CreateUser(user);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            return _userRepository.DeleteUser(user);
        }

    }
}
