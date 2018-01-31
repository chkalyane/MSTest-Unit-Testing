using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSTestingDemo;
using MSTestingDemo.Shared;


namespace MSTestingDemoTests
{
	[TestClass]
	public class MaruthiTests
	{
		[TestMethod]
		public void GetSpecifications_Default_ExpectedMaruthiSpecifications()
		{
			var expectedResult = "Maruthi Swift specifications";
			var maruthi = new Maruthi(null);
			var result = maruthi.GetSpecifications();
			result.Equals(expectedResult);
		}

		[TestMethod]
		public void FeatureMarket_Default_ExpectedDefaultFeature()
		{
			var expectedResult = "Electric";
			var maruthi = new Maruthi(null);
			var result = maruthi.FeatureMarket();
			result.Equals(expectedResult);
		}

		//Mocking Abstract Class
		[TestMethod]
		public void SaveNewModel_Default_ReturnsTrue()
		{
			var expectedResult = true;
			var mockService = new Mock<CarService>();
			mockService.Setup(_ => _.Save()).Returns(true);

			var maruthi = new Maruthi(mockService.Object);
			var result = maruthi.SaveNewModel();
			result.Equals(expectedResult);
		}

		[TestMethod]
		public void GetCarModelByID_Default_ReturnsExpected()
		{
			var expectedResult = "Maruthi";
			var mockService = new Mock<CarService>();
			mockService.Setup(_ => _.GetCarModelByID(It.IsAny<int>())).Returns("Maruthi");

			var maruthi = new Maruthi(mockService.Object);
			var result = maruthi.GetModelName();
			result.Equals(expectedResult);
		}

		//[TestMethod]
		//public void GetByID_Default_ReturnsTrue()
		//{
		//	var expectedResult = true;
		//	var mockService = new Mock<CarService>();
		//	mockService.Setup(_ => _.GetByID(It.IsAny<int>())).Returns(true);

		//	var maruthi = new Maruthi(mockService.Object);
		//	var result = maruthi.GetByID();
		//	result.Equals(expectedResult);
		//}
	}
}
