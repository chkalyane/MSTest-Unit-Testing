using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceExample.Services.AbstractEx
{
	public abstract class Campaign
	{
		public int GetCampaignByID()
		{
			return 1001;
		}

		public virtual string GetCampaignByState()
		{
			return "Delhi";
		}
	}
}