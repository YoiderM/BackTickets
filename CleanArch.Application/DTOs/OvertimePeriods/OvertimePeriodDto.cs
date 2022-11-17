using Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.OvertimePeriods
{
	public class OvertimePeriodDto : EntityWithIntId
	{
		public string StartAllowedDate { get; set; }
		public string EndAllowedDate { get; set; }
		public string StartPeriodDate { get; set; }
		public string EndPeriodDate { get; set; }
		public int? WeekNumber { get; set; }
		public int? fortnight { get; set; }
		public bool? IsOpen { get; set; }
		public bool? IsPaid { get; set; }
	}
}
