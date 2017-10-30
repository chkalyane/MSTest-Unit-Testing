using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceExample.Models;
using System.Data.SqlClient;
using System.Data;

namespace ServiceExample.Repository
{
	public class UserRepository : IUserRepository
	{
		SqlConnection connection;
		public UserRepository()
		{
			connection = new SqlConnection(@"Data Source=EPINHYDW0905\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True");
		}

		public bool CreateUser(User user)
		{
			try
			{
				var strQuery = "INSERT INTO Users(Name) " +
										"VALUES('" + user.Name + "')";
				SqlCommand command = new SqlCommand(strQuery, connection);
				connection.Open();
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public User GetUser(int ID)
		{
			if (ID <= 0)
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

		
		bool IUserRepository.DeleteUser(User user)
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