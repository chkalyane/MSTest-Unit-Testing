using UnitTestDemoUI.Models;


namespace UnitTestDemoUI.Repository
{
    public interface IUserRepository
    {
        bool Add(User user);

		User Get(int ID);

		bool Delete(User user);

	}
}
