using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models.Overtimes
{
	public class OvertimePeriod : EntityWithIntId
	{
		public DateTime? StartAllowedDate { get; set; }
		public DateTime? EndAllowedDate { get; set; }
		public DateTime? StartPeriodDate { get; set; }
		
		public DateTime? EndPeriodDate { get; set; }
		public int? WeekNumber { get; set; }
		public int? fortnight { get; set; }
		public bool? IsOpen { get; set; }
		public bool? IsPaid { get; set; }
		
		
		

	}
}
