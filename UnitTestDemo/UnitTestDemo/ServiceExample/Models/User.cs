using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceExample.Models
{
    public class User
    {
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Branch { get; set; }
		public int Age { get; set; }
		public int Salary { get; set; }
	}
}