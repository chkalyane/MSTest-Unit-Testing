using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTestingDemo.Services
{
	public class OrderService : IOrderService
	{
		public IMailService _mailService;

		public OrderService(IMailService mailService)
		{
			_mailService = mailService;
		}
		public bool GenerateOrder()
		{
			bool isOrderGenerated = false;
			if (isOrderGenerated)
			{
				_mailService.send(new Message(true));
				return true;
			}
			else
			{
				_mailService.send(new Message(false));//Customer
				_mailService.send(new Message(false));//Operations
				_mailService.send(new Message(false));//Support
				return false;
			}
		}
	}
}
