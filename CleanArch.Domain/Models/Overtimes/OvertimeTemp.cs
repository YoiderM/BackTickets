using Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Overtimes
{
    public class OvertimeTemp : Entity
	{
		public string UserDocument { get; set; }
		public string Login { get; set; }
		public string CostCenterName { get; set; }
		public string Document { get; set; }
		public string Names { get; set; }
		public string Observation { get; set; }
		public string AuthObservation { get; set; }
		public string AdminObservation { get; set; }
		public bool? UserStatus { get; set; } = true;
		public Guid? User { get; set; }

		[Column(TypeName = "decimal(10, 2)")]
		public Decimal? TotalHours { get; set; }
		public string OvertimeTypeName { get; set; }
		public Guid? OvertimeType { get; set; }
		public bool? CompensatoryApplies { get; set; }
		public bool? SundayNumber1 { get; set; } = false;
		public bool? SundayNumbre2 { get; set; } = false;
		public DateTime? OvertimeDay { get; set; }
		public DateTime? LoginTime { get; set; }
		public DateTime? InitialHour { get; set; }
		public DateTime? EndHour { get; set; }		
		public string JobName { get; set; }
		public string LoginTimeText { get; set; }
		public string Salary { get; set; }
		public string PaymentPercent{ get; set; }
		public string CompensatoryAppliesText { get; set; }
		public int? OvertimePeriodId { get; set; }
		public int? CostCenterId { get; set; }
		public int? Status { get; set; } = 1;
		

	}
}
