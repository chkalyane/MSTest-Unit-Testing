using MSTestingDemo.Models;


namespace MSTestingDemo.Repository
{
    public interface IUserRepository
    {
        bool Add(User user);

		User Get(int ID);

		bool Delete(User user);

	}
}
