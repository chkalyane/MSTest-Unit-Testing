
using MSTestingDemo.Models;

namespace Services
{
    public interface IUserService
    {
        bool Add(User user);

		User Get(int userID);

		bool Delete(User user);
	}
}
