using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceExample.Services.AbstractEx
{
	public class EducationCampaign : Campaign
	{
		public override string GetCampaignByState()
		{
			return "Mumbai";
		}
	}
}