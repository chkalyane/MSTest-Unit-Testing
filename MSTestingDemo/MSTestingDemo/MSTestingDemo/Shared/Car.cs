using MSTestingDemo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestingDemo
{
	public abstract class Car
	{
		private decimal _startingPrice = 100000;
		public abstract string GetSpecifications();

		public virtual decimal GetPrice()
		{
			return _startingPrice;
		}

		public string FeatureMarket()
		{
			return "Electric";
		}
	}

	public class Maruthi : Car
	{
		private CarService _carService;
		public Maruthi(CarService carService)
		{
			_carService = carService;
		}
		public override string GetSpecifications()
		{
			return "Maruthi Swift specifications";
		}
		public override decimal GetPrice()
		{
			return 1000000;
		}
		public bool SaveNewModel()
		{
			return _carService.Save();
		}
		public string GetModelName()
		{
			return _carService.GetCarModelByID(1);
		}
		public bool GetByID()
		{
			return _carService.GetByID(1);
		}
	}
}
