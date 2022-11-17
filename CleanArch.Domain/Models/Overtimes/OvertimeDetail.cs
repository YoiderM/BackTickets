using Core.Models.Common;
using Domain.Models.Mekano;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Overtimes
{
    public class OvertimeDetail : Entity
	{	
		
		public Guid? AprovedBy { get; set; }
		public bool? Aproved { get; set; }
		public string Login { get; set; }	
		public string JobName { get; set; }		
		public string Document { get; set; }
		public string Names { get; set; }
		public string Observation { get; set; }
		public string AuthObservation { get; set; }
		public string AdminObservation { get; set; }
		public bool? UserStatus { get; set; } = true; // active
		public Guid? User { get; set; }

		[Column(TypeName = "decimal(10, 2)")]
		public Decimal? TotalHours { get; set; }	
		public bool? CompensatoryApplies { get; set; } = false;
		public bool? SundayNumber1 { get; set; } = false;
		public bool? SundayNumbre2 { get; set; } = false;		
		public DateTime? LoginTime { get; set; }
		public DateTime? InitialHour { get; set; }
		public DateTime? EndHour { get; set; }
		public DateTime? OvertimeDay { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public Decimal? Salary { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public Decimal? PaymentPercent { get; set; }
		public int Status { get; set; } = 1;
		public int? OvertimePeriodId { get; set; }
		public int? CostCenterId { get; set; }
		public Guid OvertimeTypeId { get; set; }

		#region ForeingKey
		
		public OvertimePeriod OvertimePeriod { get; set; }
		
		public CostCenter CostCenter { get; set; }
		
		public OvertimeType OvertimeType { get; set; } 
        #endregion



    }
}
