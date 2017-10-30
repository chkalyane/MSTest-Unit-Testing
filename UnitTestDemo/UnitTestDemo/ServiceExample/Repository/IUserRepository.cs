using ServiceExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceExample.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);

		User GetUser(int ID);

		bool DeleteUser(User user);

	}
}
