using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceExample.Models;
using ServiceExample.Repository;
using ServiceExample.Services;
using System.Collections.Generic;
using System.Data;


namespace ServiceExampleTests
{

	[TestClass]
	public class UserRepositoryTests
	{
		[TestMethod]
		public void CreateUser_ValidInput_RetunTrue()
		{
			//Arrange
			var repository = new UserRepository();
			var user = new User() { Name = "Demo26th" };
			var result = true;

			//Act
			var expected = repository.CreateUser(user);

			//Assert

			Assert.AreEqual(result, expected);
		}

		[TestMethod]
		public void MockCreateUser_ValidInput_RetunTrue()
		{
			//Arrange
			var mockCommand = new Mock<IDbCommand>();
			var repository = new UserRepositoryWithDI(mockCommand.Object);
			var user = new User() { Name = "Demo26th" };
			var result = false;
			mockCommand.Setup(_ => _.ExecuteNonQuery()).Returns(0);

			//Act
			var expected = repository.CreateUser(user);

			//Assert
			Assert.AreEqual(result, expected);
		}

		[TestMethod]
		public void GetUser_WithIDisZero_RetunAdminUser()
		{
			//Arrange
			var repository = new UserRepository();
			var ID = 0;

			//Act
			var expected = repository.GetUser(0);

			//Assert

			Assert.AreEqual(expected.Name, "Job");
			Assert.AreEqual(expected.LastName, "Billy");
			Assert.AreEqual(expected.Age, 35);
		}

		[TestMethod]
		public void Mock_Divide_ValidInput_ExpectedResult()
		{
			var mailer = new Mock<IMailService>();
			Order order = new Order(mailer.Object);
			order.GenerateOrder();
			//Assert
			mailer.Verify(x => x.send(It.IsAny<Message>()), Times.Exactly(3));
		}



		#region Stub

		//Stub
		[TestMethod]
		public void Divide_ValidInput_ExpectedResult()
		{
			MailServiceStub mailer = new MailServiceStub();
			Order order = new Order(mailer);
			order.GenerateOrder();
			Assert.AreEqual(3, mailer.numberSent());
		}

		public class MailServiceStub : IMailService
		{
			private List<Message> messages = new List<Message>();
			public void send(Message msg)
			{
				messages.Add(msg);
			}
			public int numberSent()
			{
				return 3;
			}
		}

		#endregion
	}
}
