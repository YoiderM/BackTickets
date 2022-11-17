using Core.Models.Common;
using Core.Models.configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Groups
{
	public class PayrollAuthorize : Entity
	{
		public Configuration Type { get; set; }
		public Guid? TypeId { get; set; }
		
		public Guid? UserId { get; set; }
		public Guid? CampaignId { get; set; }
	
		public int Status { get; set; } = 1;
		

	}
}
