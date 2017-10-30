
namespace ServiceExample.Services
{
    public class CalculationService
    {
        public int Divide(int dividend, int divisor)
        {
            return dividend / divisor;
        }

		private int Addition(int num1, int num2)
		{
			return num1 + num2;
		}
	}
}