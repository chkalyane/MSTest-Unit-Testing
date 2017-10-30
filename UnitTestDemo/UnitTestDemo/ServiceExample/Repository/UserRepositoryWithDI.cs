using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceExample.Models;
using System.Data.SqlClient;
using System.Data;

namespace ServiceExample.Repository
{
	public class UserRepositoryWithDI : IUserRepository, IDbCommand
	{
		SqlConnection connection;
		public IDbCommand _command;


		public UserRepositoryWithDI(IDbCommand command)
		{
			connection = new SqlConnection(@"Data Source=EPINHYDW0905\SQLEXPRESS;Initial Catalog=testing;Integrated Security=True");
			_command = command;
		}

		public bool CreateUser(User user)
		{
			try
			{
				var strQuery = "INSERT INTO Users(Name) " +
										"VALUES('" + user.Name + "')";
				_command.CommandText = strQuery;
				_command.Connection = connection;
				connection.Open();
				return _command.ExecuteNonQuery() == 1;
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

		#region IDb

		IDbConnection IDbCommand.Connection
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		IDbTransaction IDbCommand.Transaction
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		string IDbCommand.CommandText
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		int IDbCommand.CommandTimeout
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		CommandType IDbCommand.CommandType
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		IDataParameterCollection IDbCommand.Parameters
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		UpdateRowSource IDbCommand.UpdatedRowSource
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}
		bool IUserRepository.DeleteUser(User user)
		{
			throw new NotImplementedException();
		}

		void IDbCommand.Prepare()
		{
			throw new NotImplementedException();
		}

		void IDbCommand.Cancel()
		{
			throw new NotImplementedException();
		}

		IDbDataParameter IDbCommand.CreateParameter()
		{
			throw new NotImplementedException();
		}

		int IDbCommand.ExecuteNonQuery()
		{
			throw new NotImplementedException();
		}

		IDataReader IDbCommand.ExecuteReader()
		{
			throw new NotImplementedException();
		}

		IDataReader IDbCommand.ExecuteReader(CommandBehavior behavior)
		{
			throw new NotImplementedException();
		}

		object IDbCommand.ExecuteScalar()
		{
			throw new NotImplementedException();
		}

		void IDisposable.Dispose()
		{
			throw new NotImplementedException();
		}
		#endregion

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