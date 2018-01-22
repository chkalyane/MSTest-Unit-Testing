using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestingDemo.Services
{
	public interface IMailService
	{
		void send(Message msg);
	}

	public class Message
	{
		public Message(bool isSuccess)
		{

		}

	}
}
