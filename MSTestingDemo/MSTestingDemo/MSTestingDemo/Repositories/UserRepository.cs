using System;
using MSTestingDemo.Models;
using System.Data.SqlClient;

namespace MSTestingDemo.Repository
{
	public class UserRepository : IUserRepository
	{
		SqlConnection connection;
		public UserRepository()
		{
			connection = new SqlConnection(@"Data Source=EPINHYDW0905\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True");
		}

		public bool Add(User user)
		{
			var strQuery = "INSERT INTO Users(Name) VALUES('" + user.Name + "')";
			SqlCommand command = new SqlCommand(strQuery, connection);
			connection.Open();
			command.ExecuteNonQuery();
			return true;
		}

		public User Get(int userID)
		{
			if (userID <= 0)
				return new User()
				{
					Name = "Job",
					LastName = "Billy",
					Age = 35,
					Branch = "Admin",
					Salary = 10000
				};
			else
				return new User();
		}


		bool IUserRepository.Delete(User user)
		{
			throw new NotImplementedException();
		}

		#region 
		//string IDbCommand.CommandText
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}

		//	set
		//	{
		//		throw new NotImplementedException();
		//	}
		//}

		//int IDbCommand.CommandTimeout
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}

		//	set
		//	{
		//		throw new NotImplementedException();
		//	}
		//}

		//CommandType IDbCommand.CommandType
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}

		//	set
		//	{
		//		throw new NotImplementedException();
		//	}
		//}

		//IDbConnection IDbCommand.Connection
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}

		//	set
		//	{
		//		throw new NotImplementedException();
		//	}
		//}

		//IDataParameterCollection IDbCommand.Parameters
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}
		//}

		//IDbTransaction IDbCommand.Transaction
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}

		//	set
		//	{
		//		throw new NotImplementedException();
		//	}
		//}

		//UpdateRowSource IDbCommand.UpdatedRowSource
		//{
		//	get
		//	{
		//		throw new NotImplementedException();
		//	}

		//	set
		//	{
		//		throw new NotImplementedException();
		//	}
		//}
		//void IDbCommand.Cancel()
		//{
		//	throw new NotImplementedException();
		//}

		//IDbDataParameter IDbCommand.CreateParameter()
		//{
		//	throw new NotImplementedException();
		//}

		//void IDisposable.Dispose()
		//{
		//	throw new NotImplementedException();
		//}

		//int IDbCommand.ExecuteNonQuery()
		//{
		//	throw new NotImplementedException();
		//}

		//IDataReader IDbCommand.ExecuteReader()
		//{
		//	throw new NotImplementedException();
		//}

		//IDataReader IDbCommand.ExecuteReader(CommandBehavior behavior)
		//{
		//	throw new NotImplementedException();
		//}

		//object IDbCommand.ExecuteScalar()
		//{
		//	throw new NotImplementedException();
		//}

		//void IDbCommand.Prepare()
		//{
		//	throw new NotImplementedException();
		//}
		#endregion
	}
}