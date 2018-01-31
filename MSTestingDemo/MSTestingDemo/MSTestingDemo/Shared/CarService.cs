using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestingDemo.Shared
{
	public abstract class CarService
	{
		public abstract bool Save();

		public virtual string GetCarModelByID(int ID)
		{
			return "Swift";
		}
		public bool GetByID(int ID)
		{
			return true;
		}
	}
}
