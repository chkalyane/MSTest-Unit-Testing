
using System;

namespace UnitTestDemoUI.Services
{
	public class CalculationService
	{
		public enum EMPDept
		{
			Admin,
			Finance,
			TA
		}
		public int Divide(int dividend, int divisor)
		{
			return dividend / divisor;
		}
		protected int Subtraction(int num1, int num2)
		{
			return num1 - num2;
		}

		private int Addition(int num1, int num2)
		{
			return num1 + num2;
		}

		public void Multiplication(int num1, int num2)
		{
			var result = num1 * num2;
		}

		public string GetDesignation(EMPDept dept, int exp)
		{
			if (exp < 0)
				throw new ArgumentNullException("experience can't be a negative value");

			switch(dept)
			{
				case EMPDept.Admin:
					if (exp <= 4)
						return "Junior Administrator";
					else if(exp >4 && exp < 8)
						return "Senior Administrator";
					else
						return "Lead Administrator";
			}
			return string.Empty;
		}

		/*Home Work
		Day-1:
		CalculationService and UserService classes
		1. Write Unit Tests for all public, private and protected
		2. Write Unit Tests for Positive and negative scenarios
		3. Write Unit Tests to handle the exception scenarios
		Note: use proper naming conventions, assertions

		Day-2:
		
		1. MsTest & Moq 
			- Developer need to understand the issue with tight coupling
			- modify the code using any DI 
			- then start writing unit test
		2. Fluent Assertions
		3. Code Coverage - explore OpenCover
		*/
	}
}