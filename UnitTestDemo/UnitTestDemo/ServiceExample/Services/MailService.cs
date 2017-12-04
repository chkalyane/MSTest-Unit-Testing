using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace UnitTestDemoUI.Services
{
	
	public class Order : IOrder
	{
		public IMailService _mailService;

		public Order(IMailService mailService)
		{
			_mailService = mailService;
		}
		public bool GenerateOrder()
		{
			bool isOrderGenerated = false;
			if(isOrderGenerated)
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

	#region 
	public class Message
	{
		public Message(bool isSuccess)
		{

		}

	}
	public interface IOrder
	{

	}
	public interface IMailService
	{
		void send(Message msg);
	}

	#endregion

}