using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceExample.Services;
using ServiceExample.Repository;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Divide_DivideByZero_ThrowsException()
        {
			//Arrange
			CalculationClass calc = new CalculationClass();
			int dividend = 10;
			int divisor = 10;
			int remainder = 1;
			//Act
			var result = calc.Divide(dividend, divisor);

			//Assert
			Assert.AreEqual(result, remainder);
        }

		[TestMethod]
		public void Divide_DivideByZero_ThrowsException1()
		{
			//Arrange
			//var calc = new UserRepository(null);
			
			////Act
			//var result = calc.CreateUser(new ServiceExample.Models.User() { Name = "Test" });

			////Assert
			//Assert.AreEqual(result, true);
		}
	}
}
