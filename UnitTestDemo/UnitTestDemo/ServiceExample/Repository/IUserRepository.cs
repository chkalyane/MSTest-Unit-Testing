using UnitTestDemoUI.Models;


namespace UnitTestDemoUI.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(User user);

		User GetUser(int ID);

		bool DeleteUser(User user);

	}
}
