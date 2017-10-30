using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1.Services
{
    [TestClass]
    public class CalculationServiceTest
    {
        [TestMethod]
        public void Divide_ValidParameters_ExpectedResult()
        {
            //AAA
            //Arrange parameter
            int numerator = 100;
            int denominator = 10;

            //Act
            var service = new ServiceExample.Services.CalculationClass();
            var result = service.Divide(numerator, denominator);

            //Assert
            var expectedResult = 10;
            Assert.AreEqual(result, expectedResult);
         }

        [TestMethod]
        public void Divide_InValidParameters_ExpectedResult()
        {
            //AAA
            //Arrange parameter
            int numerator = 100;
            int denominator = 0;

            //Act
            var service = new ServiceExample.Services.CalculationClass();
            var result = service.Divide(numerator, denominator);
         }
    }
}
