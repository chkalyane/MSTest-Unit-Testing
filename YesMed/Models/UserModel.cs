using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesMed.Models
{
    public class UserModel
    {
        public string Name { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
        public int UserTypeId { get; set; }

        public UserModel()
        { }
        public UserModel(string name, string uName, int userTypeId)
        {
            Name = name;
			UserName = uName;
            UserTypeId = userTypeId;
        }
    }
}
