using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestingDemo.Calculation;

namespace MSTestingDemoTests
{

	[TestClass]
	public class CalculationClassTests
	{
		[TestMethod]
		public void Divide_ValidInput_ExpectedResult()
		{
			//Arrange
			var service = new CalculationService();
			var dividend = 100;
			var divisor = 10;
			var result = 10;

			//Act
			var expected = service.Divide(dividend, divisor);

			//Assert
			Assert.AreEqual(result, expected);
		}

		//Unit Testing  - Private Method
		[TestMethod]
		public void Addition_ValidInput_ExpectedResult()
		{
			//Arrange
			var service = new PrivateObject(typeof(CalculationService));
			var num1 = 100;
			var num2 = 10;
			var result = 110;

			//Act
			var expected = (int)service.Invoke("Addition", num1, num2);

			//Assert
			Assert.AreEqual(result, expected);
		}

		//Unit Testing  - Protected Method
		[TestMethod]
		public void Subtraction_ValidInput_ExpectedResult()
		{
			//Arrange
			var service = new PrivateObject(typeof(CalculationService));
			var num1 = 100;
			var num2 = 10;
			var result = 90;

			//Act
			var expected = (int)service.Invoke("Subtraction", num1, num2);

			//Assert
			Assert.AreEqual(result, expected);
		}

	}
}
